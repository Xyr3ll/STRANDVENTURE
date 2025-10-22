using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STRANDVENTURE.Models
{
    public class StrandQuiz
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid StrandId { get; set; }

        [Required]
        [StringLength(120)]
        public string Title { get; set; } = string.Empty;

        [StringLength(300)]
        public string? Description { get; set; }

        // Total time limit for quiz (seconds). Null means untimed.
        public int? TimeLimitSeconds { get; set; }

        // Stored snapshot of how many questions were configured (for quick display)
        public int TotalQuestions { get; set; }

        // Runtime behavior flags
        public bool RandomizeQuestions { get; set; } = true;
        public bool RandomizeOptions { get; set; } = true;

        // Record status
        public bool IsActive { get; set; } = true;

        // Marks the single quiz currently selected (live) for the strand.
        public bool IsLive { get; set; } = false;

        [Required]
        public Guid CreatedBy { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public virtual Strand Strand { get; set; } = null!;
        public virtual Employee CreatedByEmployee { get; set; } = null!;
        // Quiz-specific questions (separate bank from assessment questions)
        public virtual ICollection<QuizQuestion> Questions { get; set; } = new List<QuizQuestion>();
    }
}
