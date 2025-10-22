using Microsoft.AspNetCore.Mvc;
using STRANDVENTURE.Models;
using STRANDVENTURE.Services;
using STRANDVENTURE.Security;
using STRANDVENTURE.Data;

namespace STRANDVENTURE.Controllers;

/// <summary>
/// Common helper base for student portal controllers (session + student resolution).
/// </summary>
public abstract class StudentPortalControllerBase : Controller
{
    protected readonly ApplicationDbContext Db;
    private readonly IStudentService _studentService;
    protected readonly IPasswordHasher PasswordHasher;

    protected StudentPortalControllerBase(ApplicationDbContext db, IStudentService studentService, IPasswordHasher passwordHasher)
    {
        Db = db;
        _studentService = studentService;
        PasswordHasher = passwordHasher;
    }

    protected bool IsStudentSession => string.Equals(HttpContext.Session.GetString("UserRole"), "Student", StringComparison.OrdinalIgnoreCase)
                                       && !string.IsNullOrWhiteSpace(HttpContext.Session.GetString("UserLRN"));

    protected async Task<Student?> GetCurrentStudentAsync(CancellationToken ct = default)
    {
        if (!IsStudentSession) return null;
        var lrn = HttpContext.Session.GetString("UserLRN");
        if (string.IsNullOrWhiteSpace(lrn)) return null;
        return await _studentService.GetByLRNAsync(lrn, ct);
    }

    protected IActionResult RedirectToStudentLogin() => RedirectToAction("StudentLogin", "Home");

    protected async Task<(Student student, IActionResult? redirect)> RequireStudentAsync(CancellationToken ct = default)
    {
        var student = await GetCurrentStudentAsync(ct);
        if (student is null)
            return (null!, RedirectToStudentLogin());
        ViewData["DisplayName"] = student.Name; // used by student layout for avatar initial
        return (student, null);
    }
}
