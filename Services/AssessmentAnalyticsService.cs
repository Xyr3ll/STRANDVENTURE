using Microsoft.EntityFrameworkCore;
using STRANDVENTURE.Data;
using STRANDVENTURE.Models;

namespace STRANDVENTURE.Services;

public interface IAssessmentAnalyticsService
{
    Task<IReadOnlyList<StudentAssessmentResult>> GetHonoredResultsAsync(IEnumerable<Guid> studentIds, CancellationToken ct = default);
    Task<IReadOnlyList<AssessmentAnalyticsService.StrandDistributionItem>> GetStrandDistributionAsync(IEnumerable<Guid> studentIds, CancellationToken ct = default);
}

public sealed class AssessmentAnalyticsService : IAssessmentAnalyticsService
{
    private readonly ApplicationDbContext _db;
    public AssessmentAnalyticsService(ApplicationDbContext db) => _db = db;

    public async Task<IReadOnlyList<StudentAssessmentResult>> GetHonoredResultsAsync(IEnumerable<Guid> studentIds, CancellationToken ct = default)
    {
        var ids = studentIds.Distinct().ToList();
        if (ids.Count == 0) return Array.Empty<StudentAssessmentResult>();

        return await _db.StudentAssessmentResults
            .Where(r => ids.Contains(r.StudentId))
            .Include(r => r.RecommendedStrand)
            .AsNoTracking()
            .ToListAsync(ct);
    }

    public async Task<IReadOnlyList<StrandDistributionItem>> GetStrandDistributionAsync(IEnumerable<Guid> studentIds, CancellationToken ct = default)
    {
        var ids = studentIds.Distinct().ToList();
        if (ids.Count == 0) return Array.Empty<StrandDistributionItem>();

        var grouped = await _db.StudentAssessmentResults
            .Where(r => ids.Contains(r.StudentId) && r.RecommendedStrandId != null)
            .Include(r => r.RecommendedStrand)
            .GroupBy(r => r.RecommendedStrand!)
            .Select(g => new { Strand = g.Key, Count = g.Count() })
            .ToListAsync(ct);

        var total = grouped.Sum(g => g.Count);
        if (total == 0) return Array.Empty<StrandDistributionItem>();

        return grouped
            .OrderByDescending(g => g.Count)
            .Select(g => new StrandDistributionItem(
                g.Strand.Id,
                g.Strand.Name,
                g.Strand.Color,
                g.Count,
                Math.Round(g.Count * 100.0 / total, 1)))
            .ToList();
    }

    public record StrandDistributionItem(Guid StrandId, string Name, string Color, int Count, double Percent);
}
