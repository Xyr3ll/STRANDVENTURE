using STRANDVENTURE.Models;

namespace STRANDVENTURE.Services;

public interface IEmployeeService
{
    Task<Employee?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<Employee?> GetByEmailAsync(string email, CancellationToken ct = default);
    Task<IReadOnlyList<Employee>> ListActiveAsync(CancellationToken ct = default);
    Task<IReadOnlyList<Employee>> ListAllAsync();
    Task<Employee> CreateAsync(Employee employee, CancellationToken ct = default);
    Task UpdateAsync(Employee employee, CancellationToken ct = default);
    Task<bool> DeleteByIdAsync(Guid id, CancellationToken ct = default);
    Task<bool> DeleteByEmailAsync(string email, CancellationToken ct = default);
}