using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STRANDVENTURE.Models;

// Master list of possible achievements a student can earn related to assessments
public class Achievement
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [MaxLength(80)]
    public string Code { get; set; } = string.Empty; // e.g. FIRST_ATTEMPT_COMPLETE

    [Required]
    [MaxLength(120)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(300)]
    public string? Description { get; set; }

    public bool IsActive { get; set; } = true;

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Optional category/tag for grouping
    [MaxLength(40)]
    public string? Category { get; set; }

    // Optional icon (CSS class or emoji)
    [MaxLength(40)]
    public string? Icon { get; set; }

    // Rarity indicator (e.g. common, rare, epic) - free-form
    [MaxLength(20)]
    public string? Rarity { get; set; }

    public virtual ICollection<StudentAssessmentAchievement> StudentAchievements { get; set; } = new List<StudentAssessmentAchievement>();
}
