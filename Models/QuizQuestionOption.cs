using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STRANDVENTURE.Models;

public class QuizQuestionOption
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public Guid QuizQuestionId { get; set; }

    [Required]
    [StringLength(1)]
    public string Letter { get; set; } = string.Empty; // A-D

    [Required]
    [StringLength(300)]
    public string Text { get; set; } = string.Empty;

    public bool IsCorrect { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Navigation
    public QuizQuestion QuizQuestion { get; set; } = null!;
}
