using STRANDVENTURE.Models;
using Microsoft.AspNetCore.Mvc; // ADDED

namespace STRANDVENTURE.Services;

public sealed class QuestionOptionService : IQuestionOptionService
{
    private readonly IRepository<QuestionOption> _repo;

    public QuestionOptionService(IRepository<QuestionOption> repo) => _repo = repo;

    public Task<QuestionOption?> GetAsync(Guid questionId, string optionLetter, CancellationToken ct = default) =>
        _repo.FirstOrDefaultAsync(o => o.QuestionId == questionId && o.OptionLetter == optionLetter, ct);

    public Task<QuestionOption?> GetByIdAsync(Guid id, CancellationToken ct = default) =>              // ADDED
        _repo.FirstOrDefaultAsync(o => o.Id == id, ct);                                                // ADDED

    public async Task<IReadOnlyList<QuestionOption>> ListByQuestionAsync(Guid questionId, CancellationToken ct = default) =>
        await _repo.ListAsync(o => o.QuestionId == questionId, ct);

    public async Task<QuestionOption> CreateAsync(QuestionOption option, CancellationToken ct = default)
    {
        await _repo.AddAsync(option, ct);
        await _repo.SaveChangesAsync(ct);
        return option;
    }

    public async Task UpdateAsync(QuestionOption option, CancellationToken ct = default)
    {
        _repo.Update(option);
        await _repo.SaveChangesAsync(ct);
    }

    public async Task<bool> DeleteAsync(Guid questionId, string optionLetter, CancellationToken ct = default)
    {
        var existing = await GetAsync(questionId, optionLetter, ct);
        if (existing is null) return false;
        _repo.Remove(existing);
        await _repo.SaveChangesAsync(ct);
        return true;
    }
}