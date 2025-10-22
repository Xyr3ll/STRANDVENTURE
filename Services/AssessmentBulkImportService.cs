using System.Globalization;
using System.Text;
using Microsoft.EntityFrameworkCore;
using STRANDVENTURE.Data;
using STRANDVENTURE.Models;

namespace STRANDVENTURE.Services;

public class AssessmentBulkImportService : IAssessmentBulkImportService
{
    private readonly ApplicationDbContext _db;
    private static readonly string[] StrandColumns = new[]
    {
        // Primary (using en dash) + ASCII hyphen fallback variants to be lenient with exported CSVs
        "Weight_Tourism",
        "Weight_Culinary",
        "Weight_Graphics",
        "Weight_ABM",
        "Weight_HUMSS–VG", // en dash
        "Weight_HUMSS-VG", // hyphen
        "Weight_Software Dev",
        "Weight_STEM–Med", // en dash
        "Weight_STEM-Med", // hyphen
        "Weight_STEM–Eng", // en dash
        "Weight_STEM-Eng"  // hyphen
    };

    // Dictionary includes original & normalized (dash-normalized) keys
    private readonly Dictionary<string, Guid> _strandNameToId;
    private readonly HashSet<string> _unmatchedWeightColumns = new(StringComparer.OrdinalIgnoreCase);

    public AssessmentBulkImportService(ApplicationDbContext db)
    {
        _db = db;
        _strandNameToId = new Dictionary<string, Guid>(StringComparer.OrdinalIgnoreCase);
        var strands = _db.Strands.AsNoTracking().ToList();
        foreach (var s in strands)
        {
            var key = s.Name.Trim().ToUpperInvariant();
            var norm = NormalizeStrandName(key);
            _strandNameToId[key] = s.Id;      // original
            _strandNameToId[norm] = s.Id;     // normalized
            // Also add variant where spaces removed (safety for accidental template edits)
            _strandNameToId[norm.Replace(" ","")] = s.Id;
        }
    }

    private static string NormalizeStrandName(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) return string.Empty;
        name = name.ToUpperInvariant().Trim();
        // Replace any unicode dash variants with ASCII hyphen '-'
        name = name
            .Replace('\u2013', '-') // en dash
            .Replace('\u2014', '-') // em dash
            .Replace('\u2212', '-') // minus sign
            .Replace('\uFFFD', '-') // replacement char (�) -> treat as hyphen
            .Replace('–','-')
            .Replace('—','-')
            .Replace('�','-'); // safety if already shown as literal
        // Collapse multiple spaces
        while (name.Contains("  ")) name = name.Replace("  ", " ");
        return name;
    }

    private class RawRow
    {
        public int QuestionOrder { get; set; }
        public string QuestionText { get; set; } = string.Empty;
        public string OptionLetter { get; set; } = string.Empty;
        public string OptionText { get; set; } = string.Empty;
        public Dictionary<string, decimal> Weights { get; } = new();
    }

    public async Task<AssessmentBulkImportReport> ImportAsync(Stream csvStream, Guid employeeId, bool upsert, CancellationToken ct = default)
    {
        using var reader = new StreamReader(csvStream, Encoding.UTF8, true, 1024, leaveOpen: true);
        var text = await reader.ReadToEndAsync();
        var lines = text.Replace("\r","").Split('\n', StringSplitOptions.RemoveEmptyEntries);
        if (lines.Length == 0)
            return new AssessmentBulkImportReport(0,0,0,0,0,0,new(){ "File is empty." });

        var headers = lines[0].Split(',').Select(h => h.Trim()).ToArray();

        // NEW: Normalize weight headers so dash / replacement char variants match StrandColumns
        for (int i = 0; i < headers.Length; i++)
        {
            if (headers[i].StartsWith("Weight_", StringComparison.OrdinalIgnoreCase))
            {
                var rest = headers[i].Substring("Weight_".Length);
                var norm = NormalizeStrandName(rest);
                headers[i] = "Weight_" + norm;
            }
            else if (string.Equals(headers[i], "Strand", StringComparison.OrdinalIgnoreCase))
            {
                // long format – still normalize internal dashes just in case
                headers[i] = NormalizeStrandName(headers[i]);
            }
        }

        var headerMap = headers
            .Select((h,i)=> (h: h.ToUpperInvariant(), idx: i))
            .ToDictionary(x => x.h, x => x.idx);

        bool longFormat = headerMap.ContainsKey("STRAND");

        string[] required = longFormat
            ? new[]{ "QUESTIONORDER","QUESTIONTEXT","OPTIONLETTER","OPTIONTEXT","STRAND","WEIGHT" }
            : new[]{ "QUESTIONORDER","QUESTIONTEXT","OPTIONLETTER","OPTIONTEXT" };

        var errors = new List<string>();
        foreach (var req in required)
            if (!headerMap.ContainsKey(req))
                errors.Add($"Missing required column: {req}");

        if (errors.Any())
            return new AssessmentBulkImportReport(0,0,0,0,0,0, errors);

        var rows = new List<RawRow>();
        int lineNo = 1;

        foreach (var line in lines.Skip(1))
        {
            lineNo++;
            if (string.IsNullOrWhiteSpace(line)) continue;
            var cols = SplitCsv(line, headers.Length);

            string GetField(string name)
            {
                name = name.ToUpperInvariant();
                return headerMap.TryGetValue(name, out var idx) ? cols[idx].Trim() : "";
            }

            try
            {
                var rr = new RawRow
                {
                    QuestionOrder = ParseInt(GetField("QUESTIONORDER")),
                    QuestionText  = Required(GetField("QUESTIONTEXT"), "QUESTIONTEXT"),
                    OptionLetter  = Required(GetField("OPTIONLETTER"), "OPTIONLETTER").ToUpperInvariant(),
                    OptionText    = Required(GetField("OPTIONTEXT"), "OPTIONTEXT")
                };
                if (rr.OptionLetter.Length != 1)
                    throw new Exception("OptionLetter must be 1 character (A-Z).");

                if (longFormat)
                {
                    var strandRaw = Required(GetField("STRAND"), "STRAND");
                    var strandUpper = strandRaw.ToUpperInvariant();
                    var norm = NormalizeStrandName(strandUpper);
                    Guid strandId;
                    if (!_strandNameToId.TryGetValue(strandUpper, out strandId) && !_strandNameToId.TryGetValue(norm, out strandId))
                        throw new Exception($"Unknown strand: {strandRaw}");
                    var w = ParseDecimal(GetField("WEIGHT"));
                    rr.Weights["Weight_" + strandUpper] = w; // store original casing variant
                }
                else
                {
                    foreach (var sc in StrandColumns)
                    {
                        if (headerMap.TryGetValue(sc.ToUpperInvariant(), out var cidx))
                        {
                            var val = cols[cidx].Trim();
                            if (!string.IsNullOrEmpty(val))
                            {
                                rr.Weights[sc] = ParseDecimal(val);
                                // Immediately validate mapping to a known strand (after stripping prefix)
                                var raw = sc.Substring("Weight_".Length);
                                var upper = raw.ToUpperInvariant();
                                var norm = NormalizeStrandName(upper);
                                if (!_strandNameToId.ContainsKey(upper) && !_strandNameToId.ContainsKey(norm))
                                {
                                    _unmatchedWeightColumns.Add(sc);
                                }
                            }
                        }
                    }
                }
                rows.Add(rr);
            }
            catch (Exception ex)
            {
                errors.Add($"Line {lineNo}: {ex.Message}");
            }
        }

        // Surface unmatched weight columns (informational – not blocking)
        if (_unmatchedWeightColumns.Count > 0)
        {
            errors.Add("Unmatched weight column(s) ignored: " + string.Join(", ", _unmatchedWeightColumns.OrderBy(c => c)));
        }

        if (errors.Count > 50)
        {
            errors.Add("Too many errors. Aborting.");
            return new AssessmentBulkImportReport(0,0,0,0,0,0, errors);
        }

        // Stop further processing if there are blocking errors (excluding unmatched column notice)
        var blockingErrors = errors.Where(e => !e.StartsWith("Unmatched weight column", StringComparison.OrdinalIgnoreCase)).ToList();
        if (blockingErrors.Any())
            return new AssessmentBulkImportReport(0,0,0,0,0, rows.Count, errors);

        var questionsGrouped = rows
            .GroupBy(r => r.QuestionOrder)
            .Select(g => new
            {
                Order = g.Key,
                QuestionText = g.First().QuestionText,
                Options = g.GroupBy(o => o.OptionLetter)
                           .Select(og => new
                           {
                               Letter = og.Key,
                               OptionText = og.First().OptionText,
                               Weights = MergeWeights(og.Select(x => x.Weights))
                           })
                           .ToList()
            })
            .ToList();

        foreach (var q in questionsGrouped)
        {
            if (q.Options.Count < 2)
                errors.Add($"Question {q.Order}: must have at least 2 options.");
            var dupOptions = q.Options.GroupBy(o=>o.Letter).Where(g=>g.Count()>1).Select(g=>g.Key).ToList();
            if (dupOptions.Any())
                errors.Add($"Question {q.Order}: duplicate option letter(s): {string.Join(",", dupOptions)}");
        }
        if (errors.Any(e => !e.StartsWith("Unmatched weight column", StringComparison.OrdinalIgnoreCase)))
            return new AssessmentBulkImportReport(0,0,0,0,0, rows.Count, errors);

        var targetOrders = questionsGrouped.Select(g=>g.Order).ToList();
        var existing = await _db.Questions
            .AsNoTracking()
            .Where(q => targetOrders.Contains(q.QuestionOrder))
            .ToListAsync(ct);

        var existingDict = existing.ToDictionary(q => q.QuestionOrder, q => q);

        int qCreated=0, qUpdated=0, qSkipped=0, oCreated=0, wCreated=0;

        using var trx = await _db.Database.BeginTransactionAsync(ct);
        try
        {
            foreach (var qg in questionsGrouped.OrderBy(q=>q.Order))
            {
                Question question;
                if (existingDict.TryGetValue(qg.Order, out var existingQ))
                {
                    if (!upsert)
                    {
                        qSkipped++;
                        continue;
                    }
                    question = await _db.Questions
                        .Include(q => q.QuestionOptions)
                        .ThenInclude(o => o.QuestionOptionStrandWeights)
                        .FirstAsync(q => q.Id == existingQ.Id, ct);

                    question.QuestionText = qg.QuestionText;
                    question.IsActive = true;

                    _db.QuestionOptionStrandWeights.RemoveRange(
                        question.QuestionOptions.SelectMany(o => o.QuestionOptionStrandWeights));
                    _db.QuestionOptions.RemoveRange(question.QuestionOptions);

                    qUpdated++;
                }
                else
                {
                    question = new Question
                    {
                        Id = Guid.NewGuid(),
                        QuestionOrder = qg.Order,
                        QuestionText = qg.QuestionText,
                        CreatedBy = employeeId,
                        IsActive = true
                    };
                    _db.Questions.Add(question);
                    qCreated++;
                }

                foreach (var opt in qg.Options.OrderBy(o => o.Letter))
                {
                    var option = new QuestionOption
                    {
                        Id = Guid.NewGuid(),
                        QuestionId = question.Id,
                        OptionLetter = opt.Letter,
                        OptionText = opt.OptionText
                    };
                    _db.QuestionOptions.Add(option);
                    oCreated++;

                    foreach (var kv in opt.Weights)
                    {

                        var strandNameRaw = kv.Key.Replace("Weight_", "").Trim();
                        var strandUpper = strandNameRaw.ToUpperInvariant();
                        var norm = NormalizeStrandName(strandUpper);



                        if (!_strandNameToId.TryGetValue(strandUpper, out var strandId) && !_strandNameToId.TryGetValue(norm, out strandId))
                            continue; // unknown (skip)
                        if (kv.Value == 0m) continue;

                        var weight = new QuestionOptionStrandWeight
                        {
                            Id = Guid.NewGuid(),
                            QuestionOptionId = option.Id,
                            StrandId = strandId,
                            Weight = Math.Round(kv.Value, 2)
                        };
                        _db.QuestionOptionStrandWeights.Add(weight);
                        wCreated++;
                    }
                }
            }

            await _db.SaveChangesAsync(ct);
            await trx.CommitAsync(ct);
        }
        catch (Exception ex)
        {
            await trx.RollbackAsync(ct);
            errors.Add("Transaction failed: " + ex.Message);
        }

        return new AssessmentBulkImportReport(qCreated, qUpdated, qSkipped, oCreated, wCreated, rows.Count, errors);
    }

    private static Dictionary<string, decimal> MergeWeights(IEnumerable<Dictionary<string, decimal>> dicts)
    {
        var result = new Dictionary<string, decimal>(StringComparer.OrdinalIgnoreCase);
        foreach (var d in dicts)
        {
            foreach (var kv in d)
            {
                if (result.ContainsKey(kv.Key))
                    result[kv.Key] += kv.Value;
                else
                    result[kv.Key] = kv.Value;
            }
        }
        return result;
    }

    private static int ParseInt(string v)
        => int.TryParse(v, out var i) ? i : throw new Exception($"Invalid int: {v}");

    private static decimal ParseDecimal(string v)
    {
        if (string.IsNullOrWhiteSpace(v)) return 0m;
        if (decimal.TryParse(v, NumberStyles.Number, CultureInfo.InvariantCulture, out var d))
            return d;
        throw new Exception($"Invalid decimal: {v}");
    }

    private static string Required(string v, string name)
        => string.IsNullOrWhiteSpace(v) ? throw new Exception($"{name} required") : v.Trim();

    private static string[] SplitCsv(string line, int expectedColumns)
    {
        var parts = new List<string>();
        var sb = new StringBuilder();
        bool inQuotes = false;
        for (int i=0;i<line.Length;i++)
        {
            var c = line[i];
            if (c=='"')
            {
                inQuotes = !inQuotes;
                continue;
            }
            if (c==',' && !inQuotes)
            {
                parts.Add(sb.ToString());
                sb.Clear();
            }
            else sb.Append(c);
        }
        parts.Add(sb.ToString());
        while (parts.Count < expectedColumns) parts.Add("");
        return parts.ToArray();
    }
}