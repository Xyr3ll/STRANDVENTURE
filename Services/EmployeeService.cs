using STRANDVENTURE.Models;

namespace STRANDVENTURE.Services;

public sealed class EmployeeService : IEmployeeService
{
    private readonly IRepository<Employee> _repo;

    public EmployeeService(IRepository<Employee> repo) => _repo = repo;

    public Task<Employee?> GetByIdAsync(Guid id, CancellationToken ct = default) =>
        _repo.FirstOrDefaultAsync(e => e.Id == id, ct);

    public Task<Employee?> GetByEmailAsync(string email, CancellationToken ct = default) =>
        _repo.FirstOrDefaultAsync(e => e.Email == email, ct);

    public async Task<IReadOnlyList<Employee>> ListActiveAsync(CancellationToken ct = default) =>
        await _repo.ListAsync(e => e.IsActive, ct);

    public async Task<IReadOnlyList<Employee>> ListAllAsync() =>
        await _repo.ListAsync();

    public async Task<Employee> CreateAsync(Employee employee, CancellationToken ct = default)
    {
        await _repo.AddAsync(employee, ct);
        await _repo.SaveChangesAsync(ct);
        return employee;
    }

    public async Task UpdateAsync(Employee employee, CancellationToken ct = default)
    {
        _repo.Update(employee);
        await _repo.SaveChangesAsync(ct);
    }

    public async Task<bool> DeleteByIdAsync(Guid id, CancellationToken ct = default)
    {
        var existing = await _repo.FirstOrDefaultAsync(e => e.Id == id, ct);
        if (existing is null) return false;
        _repo.Remove(existing);
        await _repo.SaveChangesAsync(ct);
        return true;
    }

    public async Task<bool> DeleteByEmailAsync(string email, CancellationToken ct = default)
    {
        var existing = await _repo.FirstOrDefaultAsync(e => e.Email == email, ct);
        if (existing is null) return false;
        _repo.Remove(existing);
        await _repo.SaveChangesAsync(ct);
        return true;
    }
}