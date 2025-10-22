using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STRANDVENTURE.Data;
using STRANDVENTURE.Models;
using STRANDVENTURE.Services;
using System.ComponentModel.DataAnnotations;
using static System.Collections.Specialized.BitVector32;
using Section = STRANDVENTURE.Models.Section;

namespace STRANDVENTURE.Controllers
{
    public class SectionManagementController : Controller
    {
        private readonly ILogger<SectionManagementController> _logger;
        private readonly IEmployeeService _employeeService;
        private readonly ISectionService _sectionService;
        private readonly ApplicationDbContext _db;

        public SectionManagementController(
            ILogger<SectionManagementController> logger,
            IEmployeeService employeeService,
            ISectionService sectionService,
            ApplicationDbContext db)
        {
            _logger = logger;
            _employeeService = employeeService;
            _sectionService = sectionService;
            _db = db;
        }

        private async Task<Employee?> GetCurrentEmployeeAsync()
        {
            var email = HttpContext.Session.GetString("UserEmail");
            if (string.IsNullOrWhiteSpace(email)) return null;
            return await _employeeService.GetByEmailAsync(email);
        }

        private async Task<bool> EnsureSuperAdminAsync()
        {
            
            if (HttpContext.Session.GetString("UserRole") != "SuperAdmin")
                return false;

            var emp = await GetCurrentEmployeeAsync();
            return emp is not null && emp.Role == EmployeeRole.SuperAdmin;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Index()
        {
            if (!await EnsureSuperAdminAsync())
                return Forbid();

            var emp = await GetCurrentEmployeeAsync();
            ViewData["PortalTitle"] = "Super Admin Portal";
            ViewData["DisplayName"] = emp?.Name ?? "";
            var vm = new TeacherPortalViewModel { Employee = emp ?? new Employee() };
            return View(vm);
        }

        // SuperAdmin: list all active sections (Ajax)
        // Duplicate ListSections removed. Only keep the correct version below.

        public sealed class CreateSectionRequest
        {
            public string Name { get; set; } = string.Empty;
            public int GradeLevel { get; set; }
            public bool IsActive { get; set; } = true;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSection([FromBody] CreateSectionRequest req, CancellationToken ct)
        {
            if (!await EnsureSuperAdminAsync())
                return Forbid();

            if (!ModelState.IsValid || string.IsNullOrWhiteSpace(req.Name) || req.GradeLevel <= 0)
                return BadRequest(new { message = "Invalid payload." });

            var section = new Section
            {
                Name = req.Name.Trim(),
                GradeLevel = req.GradeLevel,
                IsActive = req.IsActive
            };

            section = await _sectionService.CreateAsync(section, ct);
            return Ok(new { success = true, id = section.Id });
        }

        public sealed class UpdateSectionRequest
        {
            public Guid Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public int GradeLevel { get; set; }
            public bool IsActive { get; set; }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSection([FromBody] UpdateSectionRequest req, CancellationToken ct)
        {
            if (!await EnsureSuperAdminAsync())
                return Forbid();

            if (!ModelState.IsValid || req.Id == Guid.Empty || string.IsNullOrWhiteSpace(req.Name) || req.GradeLevel <= 0)
                return BadRequest(new { message = "Invalid payload." });

            var existing = await _sectionService.GetByIdAsync(req.Id, ct);
            if (existing is null)
                return NotFound(new { message = "Section not found." });

            existing.Name = req.Name.Trim();
            existing.GradeLevel = req.GradeLevel;
            existing.IsActive = req.IsActive;

            await _sectionService.UpdateAsync(existing, ct);
            return Ok(new { success = true });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSection([FromBody] Guid id, CancellationToken ct)
        {
            if (!await EnsureSuperAdminAsync())
                return Forbid();

            if (id == Guid.Empty)
                return BadRequest(new { message = "Invalid section id." });

            var existing = await _sectionService.GetByIdAsync(id, ct);
            if (existing is null)
                return NotFound(new { message = "Section not found." });

            // Block delete if section has students
            var hasStudents = await _db.SectionStudents.AnyAsync(ss => ss.SectionId == id, ct);
            if (hasStudents)
                return Conflict(new { message = "Cannot delete section - it has enrolled students." });

            var ok = await _sectionService.DeleteByIdAsync(id, ct);
            if (!ok) return StatusCode(500, new { message = "Unable to delete section." });

            return Ok(new { success = true });
        }

        // -------- NEW: CanDelete precheck --------
        public sealed class BulkDeleteSectionsRequest
        {
            [Required, MinLength(1)]
            public List<Guid> Ids { get; set; } = new();
        }

        [HttpPost]
        public async Task<IActionResult> CanDeleteSections([FromBody] BulkDeleteSectionsRequest req, CancellationToken ct)
        {
            if (!await EnsureSuperAdminAsync())
                return Forbid();
            if (req is null || req.Ids is null || req.Ids.Count == 0)
                return BadRequest(new { message = "No ids provided." });

            var ids = req.Ids.Distinct().ToList();

            var existing = await _db.Sections
                .Where(s => ids.Contains(s.Id))
                .Select(s => new { s.Id, s.Name })
                .ToListAsync(ct);

            var existingIds = existing.Select(x => x.Id).ToList();
            var nameById = existing.ToDictionary(x => x.Id, x => x.Name);

            var notFound = ids.Except(existingIds).ToList();
            var inUse = new List<object>();
            var ok = new List<Guid>();

            foreach (var id in existingIds)
            {
                var hasStudents = await _db.SectionStudents.AnyAsync(ss => ss.SectionId == id, ct);
                if (hasStudents)
                {
                    inUse.Add(new { id = nameById[id].ToString(), reason = " has enrolled students." });
                }
                else ok.Add(id);
            }

            return Ok(new { ok, notFound, inUse });
        }

        [HttpPost]
        public async Task<IActionResult> BulkDeleteSections([FromBody] BulkDeleteSectionsRequest req, CancellationToken ct)
        {
            if (!await EnsureSuperAdminAsync())
                return Forbid();

            if (req is null || req.Ids is null || req.Ids.Count == 0)
                return BadRequest(new { message = "No ids provided." });

            var ids = req.Ids.Distinct().ToList();
            int deleted = 0;
            var notFound = new List<Guid>();
            var errors = new List<string>();

            foreach (var id in ids)
            {
                // ...existing code for bulk delete...
            }
            return Ok(new { success = errors.Count == 0, requested = ids.Count, deleted, notFound, errors });
        }

        [HttpGet]
        public async Task<IActionResult> ListSections(CancellationToken ct)
        {
            if (!await EnsureSuperAdminAsync())
                return Forbid();

            var sections = await _sectionService.ListActiveAsync(ct);

            var data = sections
                .OrderBy(s => s.Name)
                .Select(s => new
                {
                    id = s.Id,
                    name = s.Name,
                    gradeLevel = s.GradeLevel,
                    isActive = s.IsActive,
                    createdAt = s.CreatedAt
                })
                .ToList();

            return Json(new { data });
        }

        [HttpGet]
        public async Task<IActionResult> ListTeachers(CancellationToken ct)
        {
            if (!await EnsureSuperAdminAsync())
                return Forbid();

            var employees = await _employeeService.ListActiveAsync(ct);
            var teachers = employees
                .Where(e => e.Role == EmployeeRole.Teacher)
                .OrderBy(e => e.Name)
                .Select(e => new { id = e.Id, name = e.Name, email = e.Email })
                .ToList();

            return Json(new { data = teachers });
        }
    }
}