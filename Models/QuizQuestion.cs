using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STRANDVENTURE.Models;

public class QuizQuestion
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public Guid StrandQuizId { get; set; }

    [Required]
    [StringLength(500)]
    public string Text { get; set; } = string.Empty;

    // Optional explicit ordering (else randomization / insertion order used)
    public int? DisplayOrder { get; set; }

    public bool IsActive { get; set; } = true;

    [Required]
    public Guid CreatedBy { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Navigation
    public StrandQuiz StrandQuiz { get; set; } = null!;
    public Employee CreatedByEmployee { get; set; } = null!;
    public ICollection<QuizQuestionOption> Options { get; set; } = new List<QuizQuestionOption>();
}
