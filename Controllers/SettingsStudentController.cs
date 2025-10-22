using Microsoft.AspNetCore.Mvc;
using STRANDVENTURE.Data;
using STRANDVENTURE.Models;
using STRANDVENTURE.Security;
using STRANDVENTURE.Services;

namespace STRANDVENTURE.Controllers;

public class SettingsStudentController : StudentPortalControllerBase
{
    private readonly IStudentService _studentService;

    public SettingsStudentController(ApplicationDbContext db, IStudentService studentService, IPasswordHasher passwordHasher)
        : base(db, studentService, passwordHasher) {
        _studentService = studentService;
    }

    [HttpGet]
    public async Task<IActionResult> Index(CancellationToken ct)
    {
        var (student, redirect) = await RequireStudentAsync(ct);
        if (redirect != null) return redirect;
        var vm = new StudentSettingsViewModel { Student = student };
        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ChangePassword(StudentSettingsViewModel model, CancellationToken ct)
    {
        var (student, redirect) = await RequireStudentAsync(ct);
        if (redirect != null) return redirect;

        if (string.IsNullOrWhiteSpace(model.PasswordChange.CurrentPassword) ||
            string.IsNullOrWhiteSpace(model.PasswordChange.NewPassword) ||
            string.IsNullOrWhiteSpace(model.PasswordChange.ConfirmPassword))
        {
            model.Student = student;
            model.ErrorMessage = "All password fields are required.";
            return View("Index", model);
        }

        if (!PasswordHasher.Verify(model.PasswordChange.CurrentPassword, student.PasswordHash))
        {
            model.Student = student;
            model.ErrorMessage = "Current password is incorrect.";
            return View("Index", model);
        }

        if (!string.Equals(model.PasswordChange.NewPassword, model.PasswordChange.ConfirmPassword, StringComparison.Ordinal))
        {
            model.Student = student;
            model.ErrorMessage = "Passwords do not match.";
            return View("Index", model);
        }

        student.PasswordHash = PasswordHasher.Hash(model.PasswordChange.NewPassword);
        await _studentService.UpdateAsync(student, ct);

        var vm = new StudentSettingsViewModel { Student = student, SuccessMessage = "Password updated successfully." };
        return View("Index", vm);
    }
}
