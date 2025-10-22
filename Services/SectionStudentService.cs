using STRANDVENTURE.Models;

namespace STRANDVENTURE.Services;

public sealed class SectionStudentService : ISectionStudentService
{
    private readonly IRepository<SectionStudent> _repo;

    public SectionStudentService(IRepository<SectionStudent> repo) => _repo = repo;

    public Task<SectionStudent?> GetAsync(Guid sectionId, Guid studentId, CancellationToken ct = default) =>
        _repo.FirstOrDefaultAsync(ss => ss.SectionId == sectionId && ss.StudentId == studentId, ct);

    public async Task<IReadOnlyList<SectionStudent>> ListBySectionAsync(Guid sectionId, CancellationToken ct = default) =>
        await _repo.ListAsync(ss => ss.SectionId == sectionId, ct);

    public async Task<IReadOnlyList<SectionStudent>> ListByStudentAsync(Guid studentId, CancellationToken ct = default) =>
        await _repo.ListAsync(ss => ss.StudentId == studentId, ct);

    public async Task<SectionStudent> CreateAsync(SectionStudent link, CancellationToken ct = default)
    {
        await _repo.AddAsync(link, ct);
        await _repo.SaveChangesAsync(ct);
        return link;
    }

    public async Task UpdateAsync(SectionStudent link, CancellationToken ct = default)
    {
        _repo.Update(link);
        await _repo.SaveChangesAsync(ct);
    }

    public async Task<bool> DeleteAsync(Guid sectionId, Guid studentId, CancellationToken ct = default)
    {
        var existing = await GetAsync(sectionId, studentId, ct);
        if (existing is null) return false;
        _repo.Remove(existing);
        await _repo.SaveChangesAsync(ct);
        return true;
    }
}