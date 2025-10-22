using STRANDVENTURE.Models;

namespace STRANDVENTURE.Services;

public interface IStudentService
{
    Task<Student?> GetByLRNAsync(string lrn, CancellationToken ct = default);
    Task<IReadOnlyList<Student>> ListActiveAsync(CancellationToken ct = default);
    Task<IReadOnlyList<Student>> ListAllAsync(CancellationToken ct = default);
    Task<Student> CreateAsync(Student student, CancellationToken ct = default);
    Task UpdateAsync(Student student, CancellationToken ct = default);
    Task<bool> DeleteByLRNAsync(string lrn, CancellationToken ct = default);
}