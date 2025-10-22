using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STRANDVENTURE.Data;
using STRANDVENTURE.Models;
using STRANDVENTURE.Services;
using System.ComponentModel.DataAnnotations;

namespace STRANDVENTURE.Controllers
{
    // SuperAdmin only CRUD for Strands (similar style to TeacherManagement / SectionManagement)
    public sealed class StrandManagementController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IStrandService _strandService;
        private readonly ApplicationDbContext _db;

        public StrandManagementController(IEmployeeService employeeService, IStrandService strandService, ApplicationDbContext db)
        {
            _employeeService = employeeService;
            _strandService = strandService;
            _db = db;
        }

        private bool IsSuperAdmin() => HttpContext.Session.GetString("UserRole") == "SuperAdmin";

        private async Task<Employee?> GetCurrentEmployeeAsync()
        {
            var email = HttpContext.Session.GetString("UserEmail");
            if (string.IsNullOrWhiteSpace(email)) return null;
            return await _employeeService.GetByEmailAsync(email);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (!IsSuperAdmin()) return RedirectToAction("TeacherLogin", "Home");
            var emp = await GetCurrentEmployeeAsync();
            ViewData["PortalTitle"] = "Super Admin Portal";
            ViewData["DisplayName"] = emp?.Name ?? "";
            var vm = new TeacherPortalViewModel { Employee = emp ?? new Employee() };
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> List(CancellationToken ct)
        {
            if (!IsSuperAdmin()) return Forbid();
            var list = await _db.Strands
                .OrderBy(s => s.Name)
                .Select(s => new {
                    id = s.Id,
                    name = s.Name,
                    description = s.Description,
                    color = s.Color,
                    isActive = s.IsActive,
                    createdAt = s.CreatedAt
                })
                .ToListAsync(ct);
            return Json(new { data = list });
        }

        public sealed class CreateStrandRequest
        {
            public string Name { get; set; } = string.Empty;
            public string? Description { get; set; }
            public string Color { get; set; } = "#000000";
            public bool IsActive { get; set; } = true;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStrandRequest req, CancellationToken ct)
        {
            if (!IsSuperAdmin()) return Forbid();
            if (string.IsNullOrWhiteSpace(req.Name) || string.IsNullOrWhiteSpace(req.Color))
                return BadRequest(new { message = "Name and Color are required." });

            var existing = await _strandService.GetByNameAsync(req.Name.Trim(), ct);
            if (existing is not null)
                return Conflict(new { message = "Strand name already exists." });

            var strand = new Strand
            {
                Name = req.Name.Trim(),
                Description = string.IsNullOrWhiteSpace(req.Description) ? null : req.Description.Trim(),
                Color = req.Color.Trim(),
                IsActive = req.IsActive
            };
            await _strandService.CreateAsync(strand, ct);
            return Ok(new { success = true, id = strand.Id });
        }

        public sealed class UpdateStrandRequest
        {
            public Guid Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public string? Description { get; set; }
            public string Color { get; set; } = "#000000";
            public bool IsActive { get; set; }
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] UpdateStrandRequest req, CancellationToken ct)
        {
            if (!IsSuperAdmin()) return Forbid();
            if (req.Id == Guid.Empty || string.IsNullOrWhiteSpace(req.Name) || string.IsNullOrWhiteSpace(req.Color))
                return BadRequest(new { message = "Invalid payload." });

            var strand = await _strandService.GetByIdAsync(req.Id, ct);
            if (strand is null) return NotFound(new { message = "Strand not found." });

            // unique name (allow same record)
            var byName = await _strandService.GetByNameAsync(req.Name.Trim(), ct);
            if (byName is not null && byName.Id != strand.Id)
                return Conflict(new { message = "Strand name already exists." });

            strand.Name = req.Name.Trim();
            strand.Description = string.IsNullOrWhiteSpace(req.Description) ? null : req.Description.Trim();
            strand.Color = req.Color.Trim();
            strand.IsActive = req.IsActive;
            await _strandService.UpdateAsync(strand, ct);
            return Ok(new { success = true });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
        {
            if (!IsSuperAdmin()) return Forbid();
            if (id == Guid.Empty) return BadRequest(new { message = "Invalid id." });

            // Block delete if dependencies exist
            var hasWeights = await _db.QuestionOptionStrandWeights.AnyAsync(w => w.StrandId == id, ct);
            var hasQuizzes = await _db.StrandQuizzes.AnyAsync(q => q.StrandId == id, ct);
            if (hasWeights || hasQuizzes)
                return Conflict(new { message = "Cannot delete strand - it is referenced by other records." });

            var ok = await _strandService.DeleteByIdAsync(id, ct);
            if (!ok) return NotFound(new { message = "Strand not found." });
            return Ok(new { success = true });
        }

        // -------- NEW: Pre-check and bulk delete with dependency detection --------
        public sealed class BulkDeleteStrandsRequest
        {
            [Required, MinLength(1)]
            public List<Guid> Ids { get; set; } = new();
        }

        [HttpPost]
        public async Task<IActionResult> CanDelete([FromBody] BulkDeleteStrandsRequest req, CancellationToken ct)
        {
            if (!IsSuperAdmin()) return Forbid();
            if (req is null || req.Ids is null || req.Ids.Count == 0)
                return BadRequest(new { message = "No ids provided." });

            var ids = req.Ids.Distinct().ToList();
            var existingIds = await _db.Strands.Where(s => ids.Contains(s.Id)).Select(s => s.Id).ToListAsync(ct);
            var notFound = ids.Except(existingIds).ToList();
            var inUse = new List<object>();
            var okIds = new List<Guid>();

            foreach (var id in existingIds)
            {
                var hasWeights = await _db.QuestionOptionStrandWeights.AnyAsync(w => w.StrandId == id, ct);
                var hasQuizzes = await _db.StrandQuizzes.AnyAsync(q => q.StrandId == id, ct);
                if (hasWeights || hasQuizzes)
                    inUse.Add(new { id, reason = hasWeights && hasQuizzes ? "Referenced by weights and quizzes." : hasWeights ? "Referenced by weights." : "Referenced by quizzes." });
                else okIds.Add(id);
            }

            return Ok(new { ok = okIds, notFound, inUse });
        }

        [HttpPost]
        public async Task<IActionResult> BulkDelete([FromBody] BulkDeleteStrandsRequest req, CancellationToken ct)
        {
            if (!IsSuperAdmin()) return Forbid();
            if (req is null || req.Ids is null || req.Ids.Count == 0)
                return BadRequest(new { message = "No ids provided." });

            var ids = req.Ids.Distinct().ToList();

            // Determine which exist
            var existingIds = await _db.Strands.Where(s => ids.Contains(s.Id)).Select(s => s.Id).ToListAsync(ct);
            var notFound = ids.Except(existingIds).ToList();

            // Block delete if referenced by strand quizzes or weights
            var inUseByQuiz = await _db.StrandQuizzes.Where(q => existingIds.Contains(q.StrandId)).Select(q => q.StrandId).Distinct().ToListAsync(ct);
            var inUseByWeights = await _db.QuestionOptionStrandWeights.Where(w => existingIds.Contains(w.StrandId)).Select(w => w.StrandId).Distinct().ToListAsync(ct);
            var blocked = existingIds.Union(inUseByQuiz).Union(inUseByWeights).Intersect(existingIds).Distinct().ToList();

            var deletable = existingIds.Except(blocked).ToList();
            int deleted = 0;
            var errors = new List<string>();

            if (deletable.Count > 0)
            {
                try
                {
                    var toRemove = await _db.Strands.Where(s => deletable.Contains(s.Id)).ToListAsync(ct);
                    _db.Strands.RemoveRange(toRemove);
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
                blocked,
                errors
            });
        }
    }
}
