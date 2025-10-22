using STRANDVENTURE.Models;

namespace STRANDVENTURE.Services;

public interface IStudentStrandQuizResultService
{
    Task<StudentStrandQuizResult?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<StudentStrandQuizResult?> GetLatestForStudentQuizAsync(Guid studentId, Guid quizId, CancellationToken ct = default);
    Task<List<StudentStrandQuizResult>> ListForStudentAsync(Guid studentId, int take = 50, CancellationToken ct = default);
    Task<StudentStrandQuizResult> RecordAsync(Guid studentId, Guid quizId, int totalQuestions, int correct, int shieldsRemaining, int maxStreak, CancellationToken ct = default);
    Task<int> CountAttemptsAsync(Guid studentId, Guid quizId, CancellationToken ct = default);
}
