using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STRANDVENTURE.Data;
using STRANDVENTURE.Models;
using STRANDVENTURE.Services;
using System.ComponentModel.DataAnnotations;

namespace STRANDVENTURE.Controllers
{
    // SuperAdmin only CRUD for Achievements
    public sealed class AchievementManagementController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly ApplicationDbContext _db;

        public AchievementManagementController(IEmployeeService employeeService, ApplicationDbContext db)
        {
            _employeeService = employeeService;
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
            var list = await _db.Achievements
                .OrderBy(a => a.Name)
                .Select(a => new {
                    id = a.Id,
                    code = a.Code,
                    name = a.Name,
                    description = a.Description,
                    icon = a.Icon,
                    rarity = a.Rarity,
                    category = a.Category,
                    isActive = a.IsActive,
                    createdAt = a.CreatedAt
                })
                .ToListAsync(ct);
            return Json(new { data = list });
        }

        public sealed class CreateAchievementRequest
        {
            public string Code { get; set; } = string.Empty;
            public string Name { get; set; } = string.Empty;
            public string? Description { get; set; }
            public string? Icon { get; set; }
            public string? Rarity { get; set; }
            public string? Category { get; set; }
            public bool IsActive { get; set; } = true;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAchievementRequest req, CancellationToken ct)
        {
            if (!IsSuperAdmin()) return Forbid();
            if (string.IsNullOrWhiteSpace(req.Code) || string.IsNullOrWhiteSpace(req.Name))
                return BadRequest(new { message = "Code and Name are required." });

            var dup = await _db.Achievements.AnyAsync(a => a.Code == req.Code.Trim(), ct);
            if (dup) return Conflict(new { message = "Code already exists." });

            var entity = new Achievement
            {
                Code = req.Code.Trim(),
                Name = req.Name.Trim(),
                Description = string.IsNullOrWhiteSpace(req.Description) ? null : req.Description.Trim(),
                Icon = string.IsNullOrWhiteSpace(req.Icon) ? null : req.Icon.Trim(),
                Rarity = string.IsNullOrWhiteSpace(req.Rarity) ? null : req.Rarity.Trim(),
                Category = string.IsNullOrWhiteSpace(req.Category) ? null : req.Category.Trim(),
                IsActive = req.IsActive
            };
            _db.Achievements.Add(entity);
            await _db.SaveChangesAsync(ct);
            return Ok(new { success = true, id = entity.Id });
        }

        public sealed class UpdateAchievementRequest
        {
            public Guid Id { get; set; }
            public string Code { get; set; } = string.Empty;
            public string Name { get; set; } = string.Empty;
            public string? Description { get; set; }
            public string? Icon { get; set; }
            public string? Rarity { get; set; }
            public string? Category { get; set; }
            public bool IsActive { get; set; }
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] UpdateAchievementRequest req, CancellationToken ct)
        {
            if (!IsSuperAdmin()) return Forbid();
            if (req.Id == Guid.Empty || string.IsNullOrWhiteSpace(req.Code) || string.IsNullOrWhiteSpace(req.Name))
                return BadRequest(new { message = "Invalid payload." });

            var entity = await _db.Achievements.FirstOrDefaultAsync(a => a.Id == req.Id, ct);
            if (entity is null) return NotFound(new { message = "Achievement not found." });

            var dup = await _db.Achievements.AnyAsync(a => a.Code == req.Code.Trim() && a.Id != req.Id, ct);
            if (dup) return Conflict(new { message = "Code already exists." });

            entity.Code = req.Code.Trim();
            entity.Name = req.Name.Trim();
            entity.Description = string.IsNullOrWhiteSpace(req.Description) ? null : req.Description.Trim();
            entity.Icon = string.IsNullOrWhiteSpace(req.Icon) ? null : req.Icon.Trim();
            entity.Rarity = string.IsNullOrWhiteSpace(req.Rarity) ? null : req.Rarity.Trim();
            entity.Category = string.IsNullOrWhiteSpace(req.Category) ? null : req.Category.Trim();
            entity.IsActive = req.IsActive;
            await _db.SaveChangesAsync(ct);
            return Ok(new { success = true });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
        {
            if (!IsSuperAdmin()) return Forbid();
            if (id == Guid.Empty) return BadRequest(new { message = "Invalid id." });

            var entity = await _db.Achievements.FirstOrDefaultAsync(a => a.Id == id, ct);
            if (entity is null) return NotFound(new { message = "Achievement not found." });

            // Prevent delete if referenced in student achievements
            var inUse = await _db.StudentAssessmentAchievements.AnyAsync(sa => sa.AchievementId == id, ct);
            if (inUse) return Conflict(new { message = "Cannot delete - already earned by students." });

            _db.Achievements.Remove(entity);
            await _db.SaveChangesAsync(ct);
            return Ok(new { success = true });
        }

        // -------- NEW: BULK DELETE + precheck --------
        public sealed class BulkDeleteAchievementsRequest
        {
            [Required, MinLength(1)]
            public List<Guid> Ids { get; set; } = new();
        }

        [HttpPost]
        public async Task<IActionResult> CanDelete([FromBody] BulkDeleteAchievementsRequest req, CancellationToken ct)
        {
            if (!IsSuperAdmin()) return Forbid();
            if (req is null || req.Ids is null || req.Ids.Count == 0)
                return BadRequest(new { message = "No ids provided." });

            var ids = req.Ids.Distinct().ToList();
            var existingIds = await _db.Achievements.Where(a => ids.Contains(a.Id)).Select(a => a.Id).ToListAsync(ct);
            var notFound = ids.Except(existingIds).ToList();

            var inUseIds = await _db.StudentAssessmentAchievements
                .Where(sa => existingIds.Contains(sa.AchievementId))
                .Select(sa => sa.AchievementId)
                .Distinct()
                .ToListAsync(ct);

            var okIds = existingIds.Except(inUseIds).ToList();
            var inUse = inUseIds.Select(id => new { id, reason = "Already earned by students." }).ToList();

            return Ok(new { ok = okIds, notFound, inUse });
        }

        [HttpPost]
        public async Task<IActionResult> BulkDelete([FromBody] BulkDeleteAchievementsRequest req, CancellationToken ct)
        {
            if (!IsSuperAdmin()) return Forbid();
            if (req is null || req.Ids is null || req.Ids.Count == 0)
                return BadRequest(new { message = "No ids provided." });

            var ids = req.Ids.Distinct().ToList();
            var existingIds = await _db.Achievements.Where(a => ids.Contains(a.Id)).Select(a => a.Id).ToListAsync(ct);
            var notFound = ids.Except(existingIds).ToList();

            var inUse = await _db.StudentAssessmentAchievements
                .Where(sa => existingIds.Contains(sa.AchievementId))
                .Select(sa => sa.AchievementId)
                .Distinct()
                .ToListAsync(ct);

            var deletable = existingIds.Except(inUse).ToList();
            int deleted = 0;
            var errors = new List<string>();

            if (deletable.Count > 0)
            {
                try
                {
                    var toRemove = await _db.Achievements.Where(a => deletable.Contains(a.Id)).ToListAsync(ct);
                    _db.Achievements.RemoveRange(toRemove);
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
                blocked = inUse,
                errors
            });
        }
    }
}
