using STRANDVENTURE.Models;

namespace STRANDVENTURE.Services;

public interface IStudentAssessmentAttemptService
{
    Task<IReadOnlyList<StudentAssessmentAttempt>> ListRecentCompletedAsync(IEnumerable<Guid> studentIds, int take, CancellationToken ct = default);
}
