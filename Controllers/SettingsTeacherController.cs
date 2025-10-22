using Microsoft.AspNetCore.Mvc;
using STRANDVENTURE.Models;
using STRANDVENTURE.Services;
using STRANDVENTURE.Security;

namespace STRANDVENTURE.Controllers
{
    public class SettingsTeacherController : Controller
    {
        private readonly ILogger<SettingsTeacherController> _logger;
        private readonly IEmployeeService _employeeService;
        private readonly IPasswordHasher _passwordHasher;

        public SettingsTeacherController(
            ILogger<SettingsTeacherController> logger,
            IEmployeeService employeeService,
            IPasswordHasher passwordHasher)
        {
            _logger = logger;
            _employeeService = employeeService;
            _passwordHasher = passwordHasher;
        }

        private async Task<Employee?> GetCurrentEmployeeAsync()
        {
            var role = HttpContext.Session.GetString("UserRole");
            if (role != "Teacher" && role != "SuperAdmin") return null;
            var email = HttpContext.Session.GetString("UserEmail");
            if (string.IsNullOrWhiteSpace(email)) return null;
            return await _employeeService.GetByEmailAsync(email);
        }

        [HttpGet]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Index()
        {
            var employee = await GetCurrentEmployeeAsync();
            if (employee is null) return RedirectToAction("TeacherLogin", "Home");

            ViewData["PortalTitle"] = employee.Role == EmployeeRole.SuperAdmin ? "Super Admin Portal" : "Teacher Portal";
            ViewData["DisplayName"] = employee.Name;

            var vm = new TeacherSettingsViewModel
            {
                Name = employee.Name,
                Email = employee.Email,
                Role = employee.Role.ToString(),
                Employee = employee
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(TeacherSettingsViewModel vm)
        {
            var employee = await GetCurrentEmployeeAsync();
            if (employee is null) return RedirectToAction("TeacherLogin", "Home");

            // Re-populate account details always
            vm.Name = employee.Name;
            vm.Email = employee.Email;
            vm.Role = employee.Role.ToString();
            vm.Employee = employee;

            if (!ModelState.IsValid)
            {
                vm.ErrorMessage = "Please correct the form errors.";
                return View("Index", vm);
            }

            // Validate current password
            if (!_passwordHasher.Verify(vm.PasswordChange.CurrentPassword, employee.PasswordHash))
            {
                ModelState.AddModelError("PasswordChange.CurrentPassword", "Current password is incorrect.");
                vm.ErrorMessage = "Current password is incorrect.";
                return View("Index", vm);
            }

            if (vm.PasswordChange.CurrentPassword == vm.PasswordChange.NewPassword)
            {
                ModelState.AddModelError("PasswordChange.NewPassword", "New password must be different from current password.");
                vm.ErrorMessage = "New password must be different from current password.";
                return View("Index", vm);
            }

            try
            {
                employee.PasswordHash = _passwordHasher.Hash(vm.PasswordChange.NewPassword);
                await _employeeService.UpdateAsync(employee);
                vm.SuccessMessage = "Password changed successfully.";
                vm.PasswordChange = new TeacherSettingsViewModel.ChangePasswordInput();
                _logger.LogInformation("Password updated for {Email}", employee.Email);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating password for {Email}", employee.Email);
                vm.ErrorMessage = "An error occurred while updating the password.";
            }

            return View("Index", vm);
        }
    }
}
