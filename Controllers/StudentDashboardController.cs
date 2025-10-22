using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STRANDVENTURE.Data;
using STRANDVENTURE.Models;
using STRANDVENTURE.Security;
using STRANDVENTURE.Services;

namespace STRANDVENTURE.Controllers {
    public class StudentDashboardController : StudentPortalControllerBase {
        public StudentDashboardController(ApplicationDbContext db, IStudentService studentService, IPasswordHasher passwordHasher)
            : base(db, studentService, passwordHasher) { }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Index(CancellationToken ct) {
            var (student, redirect) = await RequireStudentAsync(ct);
            if (redirect != null) return redirect;

            // Check if there is a pending notification record for this student
            var hasNotify = await Db.StudentNotifyAssessments.AsNoTracking().AnyAsync(n => n.StudentId == student.Id, ct);
            ViewData["ShowNotifyAssessmentModal"] = hasNotify;

            var attempts = await Db.StudentAssessmentAttempts
                .Where(a => a.StudentId == student.Id)
                .OrderByDescending(a => a.StartedAt)
                .ToListAsync(ct);

            var honoredAttemptId = await Db.StudentAssessmentResults
                .Where(r => r.StudentId == student.Id)
                .Select(r => (Guid?)r.AttemptId)
                .FirstOrDefaultAsync(ct);

            var strands = await Db.Strands
                .Where(s => s.IsActive)
                .OrderBy(s => s.Name)
                .Select(s => new StudentDashboardViewModel.StrandSummary { Id = s.Id, Name = s.Name })
                .ToListAsync(ct);

            var vm = new StudentDashboardViewModel {
                Student = student,
                TotalAttempts = attempts.Count,
                LastAttemptAt = attempts.FirstOrDefault()?.StartedAt,
                HasHonoredResult = honoredAttemptId.HasValue,
                Strands = strands
            };
            return View(vm);
        }
    }
}
