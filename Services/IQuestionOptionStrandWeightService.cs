using STRANDVENTURE.Models;

namespace STRANDVENTURE.Services;

public interface IQuestionOptionStrandWeightService
{
    Task<QuestionOptionStrandWeight?> GetAsync(Guid questionOptionId, Guid strandId, CancellationToken ct = default);
    Task<IReadOnlyList<QuestionOptionStrandWeight>> ListByQuestionOptionAsync(Guid questionOptionId, CancellationToken ct = default);
    Task<QuestionOptionStrandWeight> CreateAsync(QuestionOptionStrandWeight weight, CancellationToken ct = default);
    Task UpdateAsync(QuestionOptionStrandWeight weight, CancellationToken ct = default);
    Task<bool> DeleteAsync(Guid questionOptionId, Guid strandId, CancellationToken ct = default);
}