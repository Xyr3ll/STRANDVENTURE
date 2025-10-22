using STRANDVENTURE.Models;

namespace STRANDVENTURE.Services;

public interface IQuestionService
{
    Task<IReadOnlyList<QuestionListItemDto>> ListAsync(CancellationToken ct = default);
    Task<Question?> GetAsync(Guid id, CancellationToken ct = default);
    Task<bool> OrderExistsAsync(int order, Guid? excludeId = null, CancellationToken ct = default);
    Task<Question> CreateAsync(CreateQuestionDto dto, Guid createdBy, CancellationToken ct = default);
    Task<bool> UpdateAsync(UpdateQuestionDto dto, CancellationToken ct = default);
    Task<bool> DeleteAsync(Guid id, CancellationToken ct = default);
}

public sealed record QuestionListItemDto(
    Guid Id,
    int Order,
    string Text,
    bool IsActive,
    int OptionsCount
);

// Reuse these DTOs for service (kept internal to feature scope)
public sealed class CreateQuestionDto
{
    public required string QuestionText { get; set; }
    public int QuestionOrder { get; set; }
    public bool IsActive { get; set; } = true;
}
public sealed class UpdateQuestionDto
{
    public Guid Id { get; set; }
    public required string QuestionText { get; set; }
    public int QuestionOrder { get; set; }
    public bool IsActive { get; set; }
}