using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STRANDVENTURE.Models;

// Stores a persisted record of a student's standalone strand quiz completion (gamified quiz play)
public class StudentStrandQuizResult
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public Guid StudentId { get; set; }

    [Required]
    public Guid StrandQuizId { get; set; }

    // Incrementing per student per quiz (1,2,3...) to track retakes
    public int AttemptNumber { get; set; }

    public int TotalQuestions { get; set; }
    public int CorrectAnswers { get; set; }

    [Column(TypeName = "decimal(5,2)")]
    public decimal ScorePercent { get; set; } // 0.00 - 100.00

    public int ShieldsRemaining { get; set; }

    // Optional simple gamification stats
    public int MaxStreakAchieved { get; set; }

    // UTC timestamp when quiz finished
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CompletedAt { get; set; } = DateTime.UtcNow;

    // Navigation
    public virtual Student Student { get; set; } = null!;
    public virtual StrandQuiz StrandQuiz { get; set; } = null!;
}
