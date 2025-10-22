using STRANDVENTURE.Models;

namespace STRANDVENTURE.Services;

public sealed class QuestionOptionStrandWeightService : IQuestionOptionStrandWeightService
{
    private readonly IRepository<QuestionOptionStrandWeight> _repo;

    public QuestionOptionStrandWeightService(IRepository<QuestionOptionStrandWeight> repo) => _repo = repo;

    public Task<QuestionOptionStrandWeight?> GetAsync(Guid questionOptionId, Guid strandId, CancellationToken ct = default) =>
        _repo.FirstOrDefaultAsync(w => w.QuestionOptionId == questionOptionId && w.StrandId == strandId, ct);

    public async Task<IReadOnlyList<QuestionOptionStrandWeight>> ListByQuestionOptionAsync(Guid questionOptionId, CancellationToken ct = default) =>
        await _repo.ListAsync(w => w.QuestionOptionId == questionOptionId, ct);

    public async Task<QuestionOptionStrandWeight> CreateAsync(QuestionOptionStrandWeight weight, CancellationToken ct = default)
    {
        await _repo.AddAsync(weight, ct);
        await _repo.SaveChangesAsync(ct);
        return weight;
    }

    public async Task UpdateAsync(QuestionOptionStrandWeight weight, CancellationToken ct = default)
    {
        _repo.Update(weight);
        await _repo.SaveChangesAsync(ct);
    }

    public async Task<bool> DeleteAsync(Guid questionOptionId, Guid strandId, CancellationToken ct = default)
    {
        var existing = await GetAsync(questionOptionId, strandId, ct);
        if (existing is null) return false;
        _repo.Remove(existing);
        await _repo.SaveChangesAsync(ct);
        return true;
    }
}