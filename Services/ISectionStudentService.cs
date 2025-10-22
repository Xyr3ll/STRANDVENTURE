using STRANDVENTURE.Models;

namespace STRANDVENTURE.Services;

public interface ISectionStudentService
{
    Task<SectionStudent?> GetAsync(Guid sectionId, Guid studentId, CancellationToken ct = default);
    Task<IReadOnlyList<SectionStudent>> ListBySectionAsync(Guid sectionId, CancellationToken ct = default);
    Task<IReadOnlyList<SectionStudent>> ListByStudentAsync(Guid studentId, CancellationToken ct = default);
    Task<SectionStudent> CreateAsync(SectionStudent link, CancellationToken ct = default);
    Task UpdateAsync(SectionStudent link, CancellationToken ct = default);
    Task<bool> DeleteAsync(Guid sectionId, Guid studentId, CancellationToken ct = default);
}