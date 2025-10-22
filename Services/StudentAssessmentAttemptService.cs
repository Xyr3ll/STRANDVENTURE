using Microsoft.EntityFrameworkCore;
using STRANDVENTURE.Data;
using STRANDVENTURE.Models;

namespace STRANDVENTURE.Services;

public sealed class StudentAssessmentAttemptService : IStudentAssessmentAttemptService
{
    private readonly ApplicationDbContext _db;

    public StudentAssessmentAttemptService(ApplicationDbContext db) => _db = db;

    public async Task<IReadOnlyList<StudentAssessmentAttempt>> ListRecentCompletedAsync(IEnumerable<Guid> studentIds, int take, CancellationToken ct = default)
    {
        var ids = studentIds.Distinct().ToList();
        if (ids.Count == 0) return Array.Empty<StudentAssessmentAttempt>();

        take = Math.Clamp(take, 1, 100);

        return await _db.StudentAssessmentAttempts
            .AsNoTracking()
            .Where(a => a.IsCompleted && a.CompletedAt != null && ids.Contains(a.StudentId))
            .OrderByDescending(a => a.CompletedAt)
            .Take(take)
            .ToListAsync(ct);
    }
}
