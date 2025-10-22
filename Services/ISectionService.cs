using STRANDVENTURE.Models;

namespace STRANDVENTURE.Services;

public interface ISectionService
{
    Task<Section?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<IReadOnlyList<Section>> ListActiveAsync(CancellationToken ct = default);
    Task<Section> CreateAsync(Section section, CancellationToken ct = default);
    Task UpdateAsync(Section section, CancellationToken ct = default);
    Task<bool> DeleteByIdAsync(Guid id, CancellationToken ct = default);
}