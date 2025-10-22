using STRANDVENTURE.Models;

namespace STRANDVENTURE.Services;

public interface IStrandService
{
    Task<Strand?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<Strand?> GetByNameAsync(string name, CancellationToken ct = default);
    Task<IReadOnlyList<Strand>> ListActiveAsync(CancellationToken ct = default);
    Task<Strand> CreateAsync(Strand strand, CancellationToken ct = default);
    Task UpdateAsync(Strand strand, CancellationToken ct = default);
    Task<bool> DeleteByIdAsync(Guid id, CancellationToken ct = default);
}