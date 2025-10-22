using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STRANDVENTURE.Models;

// Join entity linking an assessment attempt to an unlocked achievement for a student
public class StudentAssessmentAchievement
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public Guid AttemptId { get; set; }

    [Required]
    public Guid StudentId { get; set; }

    [Required]
    public Guid AchievementId { get; set; }

    // When unlocked
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime UnlockedAt { get; set; } = DateTime.UtcNow;

    // Optional context (score reached, etc.)
    [MaxLength(250)]
    public string? ContextInfo { get; set; }

    // Navigation
    [ForeignKey(nameof(AttemptId))]
    public virtual StudentAssessmentAttempt Attempt { get; set; } = null!;

    [ForeignKey(nameof(StudentId))]
    public virtual Student Student { get; set; } = null!;

    [ForeignKey(nameof(AchievementId))]
    public virtual Achievement Achievement { get; set; } = null!;
}
