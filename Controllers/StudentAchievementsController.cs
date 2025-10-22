using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STRANDVENTURE.Data;
using STRANDVENTURE.Models;
using STRANDVENTURE.Security;
using STRANDVENTURE.Services;

namespace STRANDVENTURE.Controllers;

public class StudentAchievementsController : StudentPortalControllerBase
{
    public StudentAchievementsController(ApplicationDbContext db, IStudentService studentService, IPasswordHasher passwordHasher)
        : base(db, studentService, passwordHasher) { }

    public async Task<IActionResult> Index(CancellationToken ct)
    {
        var (student, redirect) = await RequireStudentAsync(ct);
        if (redirect != null) return redirect;

        var earned = await Db.StudentAssessmentAchievements
            .Where(a => a.StudentId == student.Id)
            .Include(a => a.Achievement)
            .OrderByDescending(a => a.UnlockedAt)
            .Select(a => new AchievementVm
            {
                Code = a.Achievement.Code,
                Name = a.Achievement.Name,
                Description = a.Achievement.Description,
                Icon = a.Achievement.Icon,
                Rarity = a.Achievement.Rarity,
                Category = a.Achievement.Category,
                UnlockedAt = a.UnlockedAt,
                AttemptId = a.AttemptId
            })
            .ToListAsync(ct);

        var allActive = await Db.Achievements
            .Where(a => a.IsActive)
            .ToListAsync(ct);

        var unlockedCodes = earned.Select(e => e.Code).ToHashSet(StringComparer.OrdinalIgnoreCase);
        var missing = allActive
            .Where(a => !unlockedCodes.Contains(a.Code))
            .Select(a => new AchievementVm
            {
                Code = a.Code,
                Name = a.Name,
                Description = a.Description,
                Icon = a.Icon,
                Rarity = a.Rarity,
                Category = a.Category,
                UnlockedAt = null,
                AttemptId = null
            })
            .ToList();

        var vm = new StudentAchievementsPageVm
        {
            Earned = earned,
            Locked = missing
        };

        return View(vm);
    }

    public sealed class StudentAchievementsPageVm
    {
        public List<AchievementVm> Earned { get; set; } = new();
        public List<AchievementVm> Locked { get; set; } = new();
    }

    public sealed class AchievementVm
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Icon { get; set; }
        public string? Rarity { get; set; }
        public string? Category { get; set; }
        public DateTime? UnlockedAt { get; set; }
        public Guid? AttemptId { get; set; }
        public bool IsUnlocked => UnlockedAt.HasValue;
    }
}
