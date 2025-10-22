using Microsoft.EntityFrameworkCore;
using STRANDVENTURE.Data;
using STRANDVENTURE.Models;

namespace STRANDVENTURE.Services;

public interface IAssessmentProgressService
{
    Task<AssessmentProgressService.AnswerResult> RecordAnswerAsync(Guid attemptId, Guid questionId, Guid questionOptionId, CancellationToken ct = default);
}

public sealed class AssessmentProgressService : IAssessmentProgressService
{
    private readonly ApplicationDbContext _db;
    private const string HalfwayHeroCode = "HALFWAY_HERO"; // Achievement.Code seed

    public AssessmentProgressService(ApplicationDbContext db) => _db = db;

    public sealed record AnswerResult(
        StudentAssessmentAnswer Answer,
        int AnsweredSoFar,
        int TotalQuestions,
        bool HalfwayAwarded,
        Achievement? AchievementAwarded);

    public async Task<AnswerResult> RecordAnswerAsync(Guid attemptId, Guid questionId, Guid questionOptionId, CancellationToken ct = default)
    {
        // Load attempt (no tracking not needed since we may modify nav collection indirectly)
        var attempt = await _db.StudentAssessmentAttempts
            .FirstOrDefaultAsync(a => a.Id == attemptId, ct);
        if (attempt is null)
            throw new InvalidOperationException("Assessment attempt not found.");

        // Ensure question exists & active (optional business rule)
        var question = await _db.Questions.AsNoTracking().FirstOrDefaultAsync(q => q.Id == questionId && q.IsActive, ct);
        if (question is null)
            throw new InvalidOperationException("Question not found or inactive.");

        // Ensure option belongs to question
        var option = await _db.QuestionOptions.AsNoTracking().FirstOrDefaultAsync(o => o.Id == questionOptionId && o.QuestionId == questionId, ct);
        if (option is null)
            throw new InvalidOperationException("Question option invalid for question.");

        // Prevent duplicate answer (unique index also guards)
        var existing = await _db.StudentAssessmentAnswers.AsNoTracking().FirstOrDefaultAsync(a => a.AttemptId == attemptId && a.QuestionId == questionId, ct);
        if (existing != null)
            throw new InvalidOperationException("Question already answered for this attempt.");

        var answer = new StudentAssessmentAnswer
        {
            AttemptId = attemptId,
            QuestionId = questionId,
            QuestionOptionId = questionOptionId
        };
        await _db.StudentAssessmentAnswers.AddAsync(answer, ct);
        await _db.SaveChangesAsync(ct); // Persist answer first so count reflects it

        // counts after persisting
        int totalQuestions = await _db.Questions.CountAsync(q => q.IsActive, ct);
        int answeredCount = await _db.StudentAssessmentAnswers.CountAsync(a => a.AttemptId == attempt.Id, ct);

        var (halfwayAwarded, achievement) = await TryAwardHalfwayHeroAsync(attempt, answeredCount, totalQuestions, ct);

        return new AnswerResult(answer, answeredCount, totalQuestions, halfwayAwarded, achievement);
    }

    private async Task<(bool Awarded, Achievement? Achievement)> TryAwardHalfwayHeroAsync(StudentAssessmentAttempt attempt, int answeredCount, int totalQuestions, CancellationToken ct)
    {
        if (totalQuestions == 0) return (false, null);
        int halfwayThreshold = (int)Math.Ceiling(totalQuestions / 2.0);
        if (answeredCount != halfwayThreshold) return (false, null); // only when first reaching

        var achievement = await _db.Achievements.FirstOrDefaultAsync(a => a.Code == HalfwayHeroCode && a.IsActive, ct);
        if (achievement == null) return (false, null);

        // Check if student has EVER earned this achievement (across all attempts, not just current)
        bool alreadyEarnedEver = await _db.StudentAssessmentAchievements
            .AnyAsync(saa => saa.StudentId == attempt.StudentId && saa.AchievementId == achievement.Id, ct);
        if (alreadyEarnedEver) return (false, null);

        var unlock = new StudentAssessmentAchievement
        {
            AttemptId = attempt.Id,
            StudentId = attempt.StudentId,
            AchievementId = achievement.Id,
            ContextInfo = $"Reached {answeredCount}/{totalQuestions} answered questions (halfway threshold)."
        };
        await _db.StudentAssessmentAchievements.AddAsync(unlock, ct);
        await _db.SaveChangesAsync(ct);
        return (true, achievement);
    }
}
