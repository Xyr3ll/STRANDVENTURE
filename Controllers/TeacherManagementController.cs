using Microsoft.AspNetCore.Mvc;
using STRANDVENTURE.Models;
using STRANDVENTURE.Security;
using STRANDVENTURE.Services;
using System.ComponentModel.DataAnnotations;
using static STRANDVENTURE.Controllers.TeacherDashboardController;

namespace STRANDVENTURE.Controllers
{
    public sealed class TeacherManagementController : Controller
    {
        private readonly ILogger<TeacherManagementController> _logger;
        private readonly IEmployeeService _employeeService;
        private readonly ISectionService _sectionService;
        private readonly IPasswordHasher _passwordHasher;

        public TeacherManagementController(
            ILogger<TeacherManagementController> logger,
            IEmployeeService employeeService,
            ISectionService sectionService,
            IPasswordHasher passwordHasher)
        {
            _logger = logger;
            _employeeService = employeeService;
            _sectionService = sectionService;
            _passwordHasher = passwordHasher;
        }

        private bool IsSuperAdmin() => HttpContext.Session.GetString("UserRole") == "SuperAdmin";

        public class TeacherManagementViewModel
        {
            public Employee Employee { get; set; } = new Employee();
        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync(Guid id)
        {
            if (!IsSuperAdmin()) return RedirectToAction("TeacherLogin", "Home");
            ViewData["PortalTitle"] = "Super Admin Portal";
            ViewData["DisplayName"] = HttpContext.Session.GetString("UserEmail") ?? "Super Admin";

            Employee? employee = await _employeeService.GetByIdAsync(id);

            if (employee == null) {
                return NotFound();
            }


            TeacherManagementViewModel viewmodel = new TeacherManagementViewModel() {
                Employee = employee
            };

            return View(viewmodel);
        }

        // List all teachers (active + inactive) with sections count
        [HttpGet]
        public async Task<IActionResult> ListTeachers(CancellationToken ct)
        {
            if (!IsSuperAdmin()) return Unauthorized();

            var employees = await _employeeService.ListAllAsync();
            var teachers = employees
                .Where(e => e.Role == EmployeeRole.Teacher)
                .ToList();

            var data = new List<object>(teachers.Count);
            foreach (var t in teachers)
            {
                // If sections are no longer linked to teachers, just count all active sections
                var sections = await _sectionService.ListActiveAsync(ct);
                data.Add(new
                {
                    id = t.Id,
                    name = t.Name,
                    email = t.Email,
                    isActive = t.IsActive,
                    sectionsCount = sections.Count // or 0 if you want to remove this
                });
            }

            return Json(new { data });
        }

        public sealed class CreateTeacherRequest
        {
            public string Name { get; set; } = string.Empty;
            public string Email { get; set; } = string.Empty;
            public string? Password { get; set; }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeacher([FromBody] CreateTeacherRequest req, CancellationToken ct)
        {
            if (!IsSuperAdmin()) return Unauthorized();
            if (string.IsNullOrWhiteSpace(req.Name) || string.IsNullOrWhiteSpace(req.Email))
                return BadRequest(new { message = "Name and Email are required." });

            var existing = await _employeeService.GetByEmailAsync(req.Email, ct);
            if (existing is not null)
                return Conflict(new { message = "Email already exists." });

            var employee = new Employee
            {
                Name = req.Name.Trim(),
                Email = req.Email.Trim(),
                Role = EmployeeRole.Teacher,
                IsActive = true,
                PasswordHash = _passwordHasher.Hash(string.IsNullOrWhiteSpace(req.Password) ? "Teacher@123" : req.Password!)
            };

            await _employeeService.CreateAsync(employee, ct);
            return Ok(new { success = true, id = employee.Id });
        }

        public sealed class UpdateTeacherRequest
        {
            public Guid Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public string Email { get; set; } = string.Empty;
            public bool IsActive { get; set; }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTeacher([FromBody] UpdateTeacherRequest req, CancellationToken ct)
        {
            if (!IsSuperAdmin()) return Unauthorized();
            if (req.Id == Guid.Empty || string.IsNullOrWhiteSpace(req.Name) || string.IsNullOrWhiteSpace(req.Email))
                return BadRequest(new { message = "Invalid payload." });

            var employee = await _employeeService.GetByIdAsync(req.Id, ct);
            if (employee is null || employee.Role != EmployeeRole.Teacher)
                return NotFound(new { message = "Teacher not found." });

            // Email uniqueness check
            var byEmail = await _employeeService.GetByEmailAsync(req.Email.Trim(), ct);
            if (byEmail is not null && byEmail.Id != req.Id)
                return Conflict(new { message = "Email already in use by another account." });

            employee.Name = req.Name.Trim();
            employee.Email = req.Email.Trim();
            employee.IsActive = req.IsActive;

            await _employeeService.UpdateAsync(employee, ct);
            return Ok(new { success = true });
        }

        public sealed class ResetPasswordRequest
        {
            public Guid Id { get; set; }
            public string NewPassword { get; set; } = string.Empty;
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest req, CancellationToken ct)
        {
            if (!IsSuperAdmin()) return Unauthorized();
            if (req.Id == Guid.Empty || string.IsNullOrWhiteSpace(req.NewPassword))
                return BadRequest(new { message = "Invalid payload." });

            var employee = await _employeeService.GetByIdAsync(req.Id, ct);
            if (employee is null || employee.Role != EmployeeRole.Teacher)
                return NotFound(new { message = "Teacher not found." });

            employee.PasswordHash = _passwordHasher.Hash(req.NewPassword);
            await _employeeService.UpdateAsync(employee, ct);
            return Ok(new { success = true });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTeacher(Guid id, CancellationToken ct)
        {
            if (!IsSuperAdmin()) return Unauthorized();
            if (id == Guid.Empty) return BadRequest(new { message = "Invalid id." });

            var employee = await _employeeService.GetByIdAsync(id, ct);
            if (employee is null || employee.Role != EmployeeRole.Teacher)
                return NotFound(new { message = "Teacher not found." });

            var sections = await _sectionService.ListActiveAsync(ct);
            // If sections are no longer linked to teachers, skip this check or adjust logic
            // if (sections.Any())
            //     return Conflict(new { message = "Cannot delete a teacher with existing sections. Reassign or delete sections first, or deactivate the account instead." });

            var ok = await _employeeService.DeleteByIdAsync(id, ct);
            if (!ok) return StatusCode(500, new { message = "Failed to delete teacher." });

            return Ok(new { success = true });
        }

        public sealed class BulkDeleteTeachersRequest
        {
            [Required, MinLength(1)]
            public List<Guid> Ids { get; set; } = new();
        }

        // NEW: pre-check dependencies to inform the UI before delete
        [HttpPost]
        public async Task<IActionResult> CanDeleteTeachers([FromBody] BulkDeleteTeachersRequest req, CancellationToken ct)
        {
            if (!IsSuperAdmin()) return Unauthorized();
            if (req is null || req.Ids is null || req.Ids.Count == 0)
                return BadRequest(new { message = "No ids provided." });

            var ids = req.Ids.Distinct().ToList();
            var ok = new List<Guid>();
            var notFound = new List<Guid>();
            var invalidRole = new List<Guid>();
            var inUse = new List<object>();

            foreach (var id in ids)
            {
                var employee = await _employeeService.GetByIdAsync(id, ct);
                if (employee is null) { notFound.Add(id); continue; }
                if (employee.Role != EmployeeRole.Teacher) { invalidRole.Add(id); continue; }
                var sections = await _sectionService.ListActiveAsync(ct);
                // If sections are no longer linked to teachers, skip this check or adjust logic
                // if (sections.Any())
                // {
                //     inUse.Add(new { id = $"{employee.Name}", reason = " has assigned sections." });
                // }
                ok.Add(id);
            }

            return Ok(new { ok, notFound, invalidRole, inUse });
        }

        [HttpPost]
        public async Task<IActionResult> BulkDeleteTeachers([FromBody] BulkDeleteTeachersRequest req, CancellationToken ct)
        {
            if (!IsSuperAdmin()) return Unauthorized();
            if (req is null || req.Ids is null || req.Ids.Count == 0)
                return BadRequest(new { message = "No ids provided." });

            var ids = req.Ids.Distinct().ToList();
            var notFound = new List<Guid>();
            var invalidRole = new List<Guid>(); // not Teacher
            var blocked = new List<Guid>();     // has sections
            var errors = new List<string>();
            int deleted = 0;

            foreach (var id in ids)
            {
                try
                {
                    var employee = await _employeeService.GetByIdAsync(id, ct);
                    if (employee is null) { notFound.Add(id); continue; }
                    if (employee.Role != EmployeeRole.Teacher) { invalidRole.Add(id); continue; }

                    var sections = await _sectionService.ListActiveAsync(ct);
                    // If sections are no longer linked to teachers, skip this check or adjust logic
                    // if (sections.Any())
                    // {
                    //     blocked.Add(id);
                    //     continue;
                    // }

                    var ok = await _employeeService.DeleteByIdAsync(id, ct);
                    if (ok) deleted++; else errors.Add($"{id}: delete failed.");
                }
                catch (Exception ex)
                {
                    errors.Add($"{id}: {ex.Message}");
                }
            }

            return Ok(new
            {
                success = errors.Count == 0,
                requested = ids.Count,
                deleted,
                notFound,
                invalidRole,
                blocked,
                errors
            });
        }
    }
}