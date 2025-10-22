using Microsoft.EntityFrameworkCore;
using STRANDVENTURE.Data;
using STRANDVENTURE.Models;

namespace STRANDVENTURE.Services;

public sealed class StudentStrandQuizResultService : IStudentStrandQuizResultService
{
    private readonly ApplicationDbContext _db;

    public StudentStrandQuizResultService(ApplicationDbContext db)
    {
        _db = db;
    }

    public Task<StudentStrandQuizResult?> GetByIdAsync(Guid id, CancellationToken ct = default) =>
        _db.StudentStrandQuizResults.AsNoTracking().FirstOrDefaultAsync(r => r.Id == id, ct);

    public Task<StudentStrandQuizResult?> GetLatestForStudentQuizAsync(Guid studentId, Guid quizId, CancellationToken ct = default) =>
        _db.StudentStrandQuizResults.AsNoTracking()
            .Where(r => r.StudentId == studentId && r.StrandQuizId == quizId)
            .OrderByDescending(r => r.AttemptNumber)
            .FirstOrDefaultAsync(ct);

    public async Task<List<StudentStrandQuizResult>> ListForStudentAsync(Guid studentId, int take = 50, CancellationToken ct = default)
    {
        if (take <= 0) take = 50;
        return await _db.StudentStrandQuizResults.AsNoTracking()
            .Where(r => r.StudentId == studentId)
            .OrderByDescending(r => r.CompletedAt)
            .ThenByDescending(r => r.AttemptNumber)
            .Take(take)
            .ToListAsync(ct);
    }

    public async Task<int> CountAttemptsAsync(Guid studentId, Guid quizId, CancellationToken ct = default)
    {
        return await _db.StudentStrandQuizResults.AsNoTracking()
            .CountAsync(r => r.StudentId == studentId && r.StrandQuizId == quizId, ct);
    }

    public async Task<StudentStrandQuizResult> RecordAsync(Guid studentId, Guid quizId, int totalQuestions, int correct, int shieldsRemaining, int maxStreak, CancellationToken ct = default)
    {
        // compute attempt number
        int attempts = await CountAttemptsAsync(studentId, quizId, ct);
        var result = new StudentStrandQuizResult
        {
            StudentId = studentId,
            StrandQuizId = quizId,
            AttemptNumber = attempts + 1,
            TotalQuestions = totalQuestions,
            CorrectAnswers = correct,
            ScorePercent = totalQuestions > 0 ? Math.Round((decimal)correct / totalQuestions * 100m, 2) : 0m,
            ShieldsRemaining = shieldsRemaining,
            MaxStreakAchieved = maxStreak
        };
        await _db.StudentStrandQuizResults.AddAsync(result, ct);
        await _db.SaveChangesAsync(ct);
        return result;
    }
}
