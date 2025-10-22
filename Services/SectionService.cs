using STRANDVENTURE.Models;

namespace STRANDVENTURE.Services;

public sealed class SectionService : ISectionService
{
    private readonly IRepository<Section> _repo;

    public SectionService(IRepository<Section> repo) => _repo = repo;

    public Task<Section?> GetByIdAsync(Guid id, CancellationToken ct = default) =>
        _repo.FirstOrDefaultAsync(s => s.Id == id, ct);

    public async Task<IReadOnlyList<Section>> ListActiveAsync(CancellationToken ct = default) =>
        await _repo.ListAsync(s => s.IsActive, ct);


    public async Task<Section> CreateAsync(Section section, CancellationToken ct = default)
    {
        await _repo.AddAsync(section, ct);
        await _repo.SaveChangesAsync(ct);
        return section;
    }

    public async Task UpdateAsync(Section section, CancellationToken ct = default)
    {
        _repo.Update(section);
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