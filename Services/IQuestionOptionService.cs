using STRANDVENTURE.Models;

namespace STRANDVENTURE.Services;

public interface IQuestionOptionService
{
    Task<QuestionOption?> GetAsync(Guid questionId, string optionLetter, CancellationToken ct = default);
    Task<QuestionOption?> GetByIdAsync(Guid id, CancellationToken ct = default); // ADDED
    Task<IReadOnlyList<QuestionOption>> ListByQuestionAsync(Guid questionId, CancellationToken ct = default);
    Task<QuestionOption> CreateAsync(QuestionOption option, CancellationToken ct = default);
    Task UpdateAsync(QuestionOption option, CancellationToken ct = default);
    Task<bool> DeleteAsync(Guid questionId, string optionLetter, CancellationToken ct = default);
}