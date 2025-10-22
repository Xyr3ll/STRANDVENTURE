using STRANDVENTURE.Models;

namespace STRANDVENTURE.Services;

public sealed class StrandService : IStrandService
{
    private readonly IRepository<Strand> _repo;

    public StrandService(IRepository<Strand> repo) => _repo = repo;

    public Task<Strand?> GetByIdAsync(Guid id, CancellationToken ct = default) =>
        _repo.FirstOrDefaultAsync(s => s.Id == id, ct);

    public Task<Strand?> GetByNameAsync(string name, CancellationToken ct = default) =>
        _repo.FirstOrDefaultAsync(s => s.Name == name, ct);

    public async Task<IReadOnlyList<Strand>> ListActiveAsync(CancellationToken ct = default) =>
        await _repo.ListAsync(s => s.IsActive, ct);

    public async Task<Strand> CreateAsync(Strand strand, CancellationToken ct = default)
    {
        await _repo.AddAsync(strand, ct);
        await _repo.SaveChangesAsync(ct);
        return strand;
    }

    public async Task UpdateAsync(Strand strand, CancellationToken ct = default)
    {
        _repo.Update(strand);
        await _repo.SaveChangesAsync(ct);
    }

    public async Task<bool> DeleteByIdAsync(Guid id, CancellationToken ct = default)
    {
        var existing = await _repo.FirstOrDefaultAsync(s => s.Id == id, ct);
        if (existing is null) return false;
        _repo.Remove(existing);
        await _repo.SaveChangesAsync(ct);
        return true;
    }
}