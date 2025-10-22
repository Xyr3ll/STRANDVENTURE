using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STRANDVENTURE.Data;
using STRANDVENTURE.Models;
using STRANDVENTURE.Services;
using System.ComponentModel.DataAnnotations;

namespace STRANDVENTURE.Controllers
{
    public class AssessmentManagementController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IQuestionService _questionService;
        private readonly IQuestionOptionService _optionService;
        private readonly IQuestionOptionStrandWeightService _weightService;
        private readonly IEmployeeService _employeeService;
        private readonly IAssessmentBulkImportService _importService;

        public AssessmentManagementController(
            ApplicationDbContext db,
            IQuestionService questionService,
            IQuestionOptionService optionService,
            IQuestionOptionStrandWeightService weightService,
            IEmployeeService employeeService,
            IAssessmentBulkImportService importService)
        {
            _db = db;
            _questionService = questionService;
            _optionService = optionService;
            _weightService = weightService;
            _employeeService = employeeService;
            _importService = importService;
        }

        public class AssessmentManagementViewModel
        {
            public Employee Employee { get; set; } = null!;
        }

        // Question DTOs (controller-layer)
        public sealed class CreateQuestionRequest           
        {
            [Required, StringLength(500)] public string QuestionText { get; set; } = string.Empty;
            [Range(1, 999)] public int QuestionOrder { get; set; }
            public bool IsActive { get; set; } = true;
        }
        public sealed class UpdateQuestionRequest
        {
            [Required] public Guid Id { get; set; }
            [Required, StringLength(500)] public string QuestionText { get; set; } = string.Empty;
            [Range(1, 999)] public int QuestionOrder { get; set; }
            public bool IsActive { get; set; }
        }
        public sealed class DeleteQuestionRequest
        {
            [Required] public Guid Id { get; set; }
        }
        public sealed class BulkDeleteQuestionsRequest
        {
            [Required]
            [MinLength(1)]
            public List<Guid> Ids { get; set; } = new();
        }

        // Option DTOs
        public sealed class CreateOptionRequest
        {
            [Required] public Guid QuestionId { get; set; }
            [Required, StringLength(1)] public string OptionLetter { get; set; } = string.Empty;
            [Required, StringLength(300)] public string OptionText { get; set; } = string.Empty;
        }
        public sealed class UpdateOptionRequest
        {
            [Required] public Guid Id { get; set; }
            [Required, StringLength(1)] public string OptionLetter { get; set; } = string.Empty; // allow letter change
            [Required, StringLength(300)] public string OptionText { get; set; } = string.Empty;
        }
        public sealed class DeleteOptionRequest
        {
            [Required] public Guid Id { get; set; }
        }

        // Weight DTOs
        public sealed class UpsertWeightRequest
        {
            [Required] public Guid QuestionOptionId { get; set; }
            [Required] public Guid StrandId { get; set; }
            [Range(0.00, 1.00)] public decimal Weight { get; set; }
        }
        public sealed class DeleteWeightRequest
        {
            [Required] public Guid QuestionOptionId { get; set; }
            [Required] public Guid StrandId { get; set; }
        }

        private async Task<Employee?> GetCurrentEmployeeAsync()
        {
            var role = HttpContext.Session.GetString("UserRole");
            if (role is not ("Teacher" or "SuperAdmin")) return null;
            var email = HttpContext.Session.GetString("UserEmail");
            if (string.IsNullOrWhiteSpace(email)) return null;
            return await _employeeService.GetByEmailAsync(email);
        }

        public async Task<IActionResult> Index(Guid? id)
        {
            var employee = await GetCurrentEmployeeAsync();
            if (employee is null) return RedirectToAction("TeacherLogin", "Home");
            ViewData["PortalTitle"] = "Teacher Portal";
            ViewData["DisplayName"] = employee.Name;
            return View(new AssessmentManagementViewModel { Employee = employee });
        }

        // ---------------- QUESTIONS ----------------
        [HttpGet]
        public async Task<IActionResult> ListQuestions(CancellationToken ct)
        {
            var list = await _questionService.ListAsync(ct);
            var data = list.Select(q => new
            {
                id = q.Id,
                order = q.Order,
                text = q.Text,
                isActive = q.IsActive,
                optionsCount = q.OptionsCount
            });
            return Ok(new { data });
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuestion([FromBody] CreateQuestionRequest req, CancellationToken ct)
        {
            if (!ModelState.IsValid) return BadRequest(new { success = false, message = "Invalid payload." });

            if (await _questionService.OrderExistsAsync(req.QuestionOrder, null, ct))
                return BadRequest(new { success = false, message = $"Order {req.QuestionOrder} already exists." });

            var employee = await GetCurrentEmployeeAsync();
            if (employee is null) return Unauthorized(new { success = false, message = "Session expired." });

            var entity = await _questionService.CreateAsync(
                new CreateQuestionDto
                {
                    QuestionText = req.QuestionText,
                    QuestionOrder = req.QuestionOrder,
                    IsActive = req.IsActive
                }, employee.Id, ct);

            return Ok(new
            {
                success = true,
                message = "Question created.",
                data = new { id = entity.Id, order = entity.QuestionOrder, text = entity.QuestionText, isActive = entity.IsActive }
            });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateQuestion([FromBody] UpdateQuestionRequest req, CancellationToken ct)
        {
            if (!ModelState.IsValid) return BadRequest(new { success = false, message = "Invalid payload." });

            var existing = await _questionService.GetAsync(req.Id, ct);
            if (existing is null) return NotFound(new { success = false, message = "Question not found." });

            if (existing.QuestionOrder != req.QuestionOrder &&
                await _questionService.OrderExistsAsync(req.QuestionOrder, req.Id, ct))
                return BadRequest(new { success = false, message = $"Order {req.QuestionOrder} already exists." });

            var ok = await _questionService.UpdateAsync(new UpdateQuestionDto
            {
                Id = req.Id,
                QuestionText = req.QuestionText,
                QuestionOrder = req.QuestionOrder,
                IsActive = req.IsActive
            }, ct);

            return ok
                ? Ok(new { success = true, message = "Question updated." })
                : NotFound(new { success = false, message = "Question not found." });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteQuestion([FromBody] DeleteQuestionRequest req, CancellationToken ct)
        {
            if (!ModelState.IsValid) return BadRequest(new { success = false, message = "Invalid payload." });
            var ok = await _questionService.DeleteAsync(req.Id, ct);
            return ok
                ? Ok(new { success = true, message = "Question deleted." })
                : NotFound(new { success = false, message = "Question not found." });
        }

        [HttpPost]
        public async Task<IActionResult> BulkDeleteQuestions([FromBody] BulkDeleteQuestionsRequest req, CancellationToken ct)
        {
            if (!ModelState.IsValid || req.Ids is null || req.Ids.Count == 0)
                return BadRequest(new { success = false, message = "No ids provided." });

            var ids = req.Ids.Distinct().ToList();

            // Determine which ids exist
            var existingIds = await _db.Questions
                .Where(q => ids.Contains(q.Id))
                .Select(q => q.Id)
                .ToListAsync(ct);

            var notFound = ids.Except(existingIds).ToList();

            // Determine which ids are in use by student answers (cannot delete due to FK Restrict)
            var inUseIds = await _db.StudentAssessmentAnswers
                .Where(a => existingIds.Contains(a.QuestionId))
                .Select(a => a.QuestionId)
                .Distinct()
                .ToListAsync(ct);

            var deletableIds = existingIds.Except(inUseIds).ToList();

            int deleted = 0;
            var errors = new List<string>();

            if (deletableIds.Count > 0)
            {
                try
                {
                    var toRemove = await _db.Questions.Where(q => deletableIds.Contains(q.Id)).ToListAsync(ct);
                    _db.Questions.RemoveRange(toRemove);
                    deleted = await _db.SaveChangesAsync(ct);
                }
                catch (Exception ex)
                {
                    errors.Add(ex.Message);
                }
            }

            return Ok(new
            {
                success = errors.Count == 0,
                requested = ids.Count,
                deleted,
                notFound,
                blocked = inUseIds,
                errors
            });
        }

        // NEW: Pre-check which questions can be deleted (vs in-use)
        [HttpPost]
        public async Task<IActionResult> CanDeleteQuestions([FromBody] BulkDeleteQuestionsRequest req, CancellationToken ct)
        {
            if (!ModelState.IsValid || req.Ids is null || req.Ids.Count == 0)
                return BadRequest(new { message = "No ids provided." });

            var ids = req.Ids.Distinct().ToList();

            var existing = await _db.Questions
                .Where(q => ids.Contains(q.Id))
                .Select(q => new { q.Id, Text = q.QuestionText, Order = q.QuestionOrder })
                .ToListAsync(ct);

            var existingIds = existing.Select(x => x.Id).ToList();
            var infoById = existing.ToDictionary(x => x.Id, x => new { x.Text, x.Order });

            var notFound = ids.Except(existingIds).ToList();

            var inUseIds = await _db.StudentAssessmentAnswers
                .Where(a => existingIds.Contains(a.QuestionId))
                .Select(a => a.QuestionId)
                .Distinct()
                .ToListAsync(ct);

            var ok = existingIds.Except(inUseIds).ToList();

            var inUse = inUseIds.Select(id => new { id = infoById.TryGetValue(id, out var v) ? v.Text : null, order = infoById.TryGetValue(id, out var v2) ? v2.Order : (int?)null, reason = " has student answers." }).ToList();

            return Ok(new { ok, notFound, inUse });
        }

        // ---------------- OPTIONS ----------------
        [HttpGet]
        public async Task<IActionResult> ListQuestionOptions(Guid questionId, CancellationToken ct)
        {
            var options = await _optionService.ListByQuestionAsync(questionId, ct);

            // Aggregate weight counts
            var optionIds = options.Select(o => o.Id).ToList();
            var weightCounts = await _db.QuestionOptionStrandWeights
                .Where(w => optionIds.Contains(w.QuestionOptionId))
                .GroupBy(w => w.QuestionOptionId)
                .Select(g => new { g.Key, Count = g.Count() })
                .ToDictionaryAsync(x => x.Key, x => x.Count, ct);

            var data = options
                .OrderBy(o => o.OptionLetter)
                .Select(o => new
                {
                    id = o.Id,
                    letter = o.OptionLetter,
                    text = o.OptionText,
                    weightsCount = weightCounts.TryGetValue(o.Id, out var c) ? c : 0
                });

            return Ok(new { data });
        }

        [HttpPost]
        public async Task<IActionResult> CreateOption([FromBody] CreateOptionRequest req, CancellationToken ct)
        {
            if (!ModelState.IsValid) return BadRequest(new { success = false, message = "Invalid payload." });

            var letter = req.OptionLetter.Trim().ToUpperInvariant();
            if (letter.Length != 1 || letter[0] < 'A' || letter[0] > 'Z')
                return BadRequest(new { success = false, message = "OptionLetter must be A-Z." });

            var dup = await _optionService.GetAsync(req.QuestionId, letter, ct);
            if (dup != null)
                return BadRequest(new { success = false, message = $"Option '{letter}' already exists for this question." });

            var option = new QuestionOption
            {
                QuestionId = req.QuestionId,
                OptionLetter = letter,
                OptionText = req.OptionText.Trim()
            };
            await _optionService.CreateAsync(option, ct);

            return Ok(new
            {
                success = true,
                message = "Option created.",
                data = new { id = option.Id, letter = option.OptionLetter, text = option.OptionText }
            });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateOption([FromBody] UpdateOptionRequest req, CancellationToken ct)
        {
            if (!ModelState.IsValid) return BadRequest(new { success = false, message = "Invalid payload." });

            var option = await _optionService.GetByIdAsync(req.Id, ct);
            if (option is null) return NotFound(new { success = false, message = "Option not found." });

            var newLetter = req.OptionLetter.Trim().ToUpperInvariant();
            if (newLetter.Length != 1 || newLetter[0] < 'A' || newLetter[0] > 'Z')
                return BadRequest(new { success = false, message = "OptionLetter must be A-Z." });

            if (!string.Equals(option.OptionLetter, newLetter, StringComparison.OrdinalIgnoreCase))
            {
                var dup = await _optionService.GetAsync(option.QuestionId, newLetter, ct);
                if (dup != null && dup.Id != option.Id)
                    return BadRequest(new { success = false, message = $"Option '{newLetter}' already exists for this question." });
                option.OptionLetter = newLetter;
            }

            option.OptionText = req.OptionText.Trim();
            await _optionService.UpdateAsync(option, ct);

            return Ok(new { success = true, message = "Option updated." });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteOption([FromBody] DeleteOptionRequest req, CancellationToken ct)
        {
            if (!ModelState.IsValid) return BadRequest(new { success = false, message = "Invalid payload." });

            var option = await _optionService.GetByIdAsync(req.Id, ct);
            if (option is null) return NotFound(new { success = false, message = "Option not found." });

            var removed = await _optionService.DeleteAsync(option.QuestionId, option.OptionLetter, ct);
            return removed
                ? Ok(new { success = true, message = "Option deleted." })
                : NotFound(new { success = false, message = "Option not found." });
        }

        // ---------------- WEIGHTS ----------------
        [HttpGet]
        public async Task<IActionResult> ListOptionStrandWeights(Guid questionOptionId, CancellationToken ct)
        {
            var weights = await _weightService.ListByQuestionOptionAsync(questionOptionId, ct);

            var strandIds = weights.Select(w => w.StrandId).Distinct().ToList();
            var strandLookup = await _db.Strands
                .Where(s => strandIds.Contains(s.Id))
                .Select(s => new { s.Id, s.Name })
                .ToDictionaryAsync(s => s.Id, s => s.Name, ct);

            var data = weights
                .OrderBy(w => strandLookup.TryGetValue(w.StrandId, out var name) ? name : "")
                .Select(w => new
                {
                    id = w.Id,
                    strandId = w.StrandId,
                    strandName = strandLookup.TryGetValue(w.StrandId, out var n) ? n : "",
                    weight = w.Weight
                });

            return Ok(new { data });
        }

        [HttpPost]
        public async Task<IActionResult> UpsertOptionStrandWeight([FromBody] UpsertWeightRequest req, CancellationToken ct)
        {
            if (!ModelState.IsValid) return BadRequest(new { success = false, message = "Invalid payload." });
            if (req.Weight < 0m || req.Weight > 1m)
                return BadRequest(new { success = false, message = "Weight must be between 0.00 and 1.00." });

            var existing = await _weightService.GetAsync(req.QuestionOptionId, req.StrandId, ct);
            if (existing is null)
            {
                var entity = new QuestionOptionStrandWeight
                {
                    QuestionOptionId = req.QuestionOptionId,
                    StrandId = req.StrandId,
                    Weight = req.Weight
                };
                await _weightService.CreateAsync(entity, ct);
                return Ok(new { success = true, message = "Weight created." });
            }
            existing.Weight = req.Weight;
            await _weightService.UpdateAsync(existing, ct);
            return Ok(new { success = true, message = "Weight updated." });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteOptionStrandWeight([FromBody] DeleteWeightRequest req, CancellationToken ct)
        {
            if (!ModelState.IsValid) return BadRequest(new { success = false, message = "Invalid payload." });
            var removed = await _weightService.DeleteAsync(req.QuestionOptionId, req.StrandId, ct);
            return removed
                ? Ok(new { success = true, message = "Weight deleted." })
                : NotFound(new { success = false, message = "Weight not found." });
        }

        // ---------------- STRANDS (for UI selects) ----------------
        [HttpGet]
        public async Task<IActionResult> ListStrands(CancellationToken ct)
        {
            var data = await _db.Strands
                .OrderBy(s => s.Name)
                .Select(s => new { id = s.Id, name = s.Name })
                .ToListAsync(ct);
            return Ok(new { data });
        }

        // Returns only strands NOT yet assigned to the given question option
        [HttpGet]
        public async Task<IActionResult> ListAvailableStrands(Guid questionOptionId, CancellationToken ct)
        {
            var assignedIds = (await _weightService.ListByQuestionOptionAsync(questionOptionId, ct))
                .Select(w => w.StrandId)
                .ToHashSet();

            var data = await _db.Strands
                .Where(s => !assignedIds.Contains(s.Id))
                .OrderBy(s => s.Name)
                .Select(s => new { id = s.Id, name = s.Name })
                .ToListAsync(ct);

            return Ok(new { data });
        }

        // GET: download template (updated: removed Correct column for behavioral questions)
        [HttpGet]
        public IActionResult BulkUploadTemplate() {
            // Header uses Weight_<StrandName> where <StrandName> matches the seeded Strand.Name exactly
            var csv = "QuestionOrder,QuestionText,OptionLetter,OptionText,Weight_Tourism,Weight_ABM,Weight_Graphics,Weight_HUMSS–VG,Weight_Culinary,Weight_STEM–Med,Weight_STEM–Eng,Weight_Software Dev\r\n" +
                      // Sample rows (no Correct column anymore)
                      "1,Sample behavioral question 1,A,Option A,1,0,0.2,0,0.3,0.5,0,0\r\n" +
                      "1,Sample behavioral question 1,B,Option B,0,0.4,0.1,0.2,0.1,0.2,0,0\r\n" +
                      "2,Sample behavioral question 2,A,First choice,0.3,0.2,0,0.1,0.1,0.2,0.1,0\r\n" +
                      "2,Sample behavioral question 2,B,Second choice,0.1,0.1,0.1,0.2,0.1,0.3,0,0.1\r\n";
            return File(System.Text.Encoding.UTF8.GetBytes(csv), "text/csv", "assessment_template.csv");
        }

        [HttpPost]
        [RequestSizeLimit(10_000_000)]
        public async Task<IActionResult> BulkUpload([FromForm] IFormFile file, [FromQuery] string mode = "insert", CancellationToken ct = default) {
            if (file == null || file.Length == 0)
                return BadRequest(new { message = "File is required." });

            bool upsert = string.Equals(mode, "upsert", StringComparison.OrdinalIgnoreCase);

            var employee = await GetCurrentEmployeeAsync();

            using var stream = file.OpenReadStream();
            var report = await _importService.ImportAsync(stream, employee.Id, upsert, ct);

            // Return camelCase keys to match typical JS expectations
            return Ok(new {
                questionsCreated = report.QuestionsCreated,
                questionsUpdated = report.QuestionsUpdated,
                questionDuplicatesSkipped = report.QuestionDuplicatesSkipped,
                optionsCreated = report.OptionsCreated,
                weightsCreated = report.WeightsCreated,
                rowsParsed = report.RowsParsed,
                errors = report.Errors
            });
        }

        // Helper (currently unused externally)
        private Task<QuestionOption?> FindOptionByIdAsync(Guid id, CancellationToken ct) =>
            _optionService.GetByIdAsync(id, ct);
    }
}