using Microsoft.EntityFrameworkCore;
using STRANDVENTURE.Models;

namespace STRANDVENTURE.Services;

public sealed class StudentService : IStudentService
{
    private readonly IRepository<Student> _repo;

    public StudentService(IRepository<Student> repo) => _repo = repo;

    public Task<Student?> GetByLRNAsync(string lrn, CancellationToken ct = default) =>
        _repo.FirstOrDefaultAsync(s => s.LRN == lrn, ct);

    public async Task<IReadOnlyList<Student>> ListActiveAsync(CancellationToken ct = default)
        => await _repo.ListAsync(s => s.IsActive, ct);

    public async Task<Student> CreateAsync(Student student, CancellationToken ct = default)
    {
        await _repo.AddAsync(student, ct);
        await _repo.SaveChangesAsync(ct);
        return student;
    }

    public async Task UpdateAsync(Student student, CancellationToken ct = default)
    {
        _repo.Update(student);
        await _repo.SaveChangesAsync(ct);
    }

    public async Task<bool> DeleteByLRNAsync(string lrn, CancellationToken ct = default)
    {
        var existing = await _repo.FirstOrDefaultAsync(s => s.LRN == lrn, ct);
        if (existing is null) return false;
        _repo.Remove(existing);
        await _repo.SaveChangesAsync(ct);
        return true;
    }

    public async Task<IReadOnlyList<Student>> ListAllAsync(CancellationToken ct = default) 
        => await _repo.ListAsync();
}