using Microsoft.EntityFrameworkCore;
using STRANDVENTURE.Data;
using STRANDVENTURE.Models;

namespace STRANDVENTURE.Services;

public sealed class QuestionService : IQuestionService
{
    private readonly ApplicationDbContext _db;
    public QuestionService(ApplicationDbContext db) => _db = db;

    public async Task<IReadOnlyList<QuestionListItemDto>> ListAsync(CancellationToken ct = default)
    {
        return await _db.Questions
            .OrderBy(q => q.QuestionOrder)
            .Select(q => new QuestionListItemDto(
                q.Id,
                q.QuestionOrder,
                q.QuestionText,
                q.IsActive,
                q.QuestionOptions.Count))
            .ToListAsync(ct);
    }

    public Task<Question?> GetAsync(Guid id, CancellationToken ct = default) =>
        _db.Questions.FirstOrDefaultAsync(q => q.Id == id, ct);

    public Task<bool> OrderExistsAsync(int order, Guid? excludeId = null, CancellationToken ct = default) =>
        _db.Questions.AnyAsync(q => q.QuestionOrder == order && (excludeId == null || q.Id != excludeId), ct);

    public async Task<Question> CreateAsync(CreateQuestionDto dto, Guid createdBy, CancellationToken ct = default)
    {
        var entity = new Question
        {
            QuestionText = dto.QuestionText.Trim(),
            QuestionOrder = dto.QuestionOrder,
            IsActive = dto.IsActive,
            CreatedBy = createdBy
        };
        _db.Questions.Add(entity);
        await _db.SaveChangesAsync(ct);
        return entity;
    }

    public async Task<bool> UpdateAsync(UpdateQuestionDto dto, CancellationToken ct = default)
    {
        var entity = await _db.Questions.FirstOrDefaultAsync(q => q.Id == dto.Id, ct);
        if (entity is null) return false;

        entity.QuestionText = dto.QuestionText.Trim();
        entity.QuestionOrder = dto.QuestionOrder;
        entity.IsActive = dto.IsActive;

        await _db.SaveChangesAsync(ct);
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken ct = default)
    {
        var entity = await _db.Questions.FirstOrDefaultAsync(q => q.Id == id, ct);
        if (entity is null) return false;
        _db.Questions.Remove(entity);
        await _db.SaveChangesAsync(ct);
        return true;
    }
}