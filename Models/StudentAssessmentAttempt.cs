using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STRANDVENTURE.Models
{
    public class StudentAssessmentAttempt
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid StudentId { get; set; }

        // Optional attempt number if you want to track ordinal; set from app logic
        public int AttemptNumber { get; set; } = 0;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime StartedAt { get; set; } = DateTime.UtcNow;

        public DateTime? CompletedAt { get; set; }

        public bool IsCompleted { get; set; } = false;

        // Optional overall score for quick reporting (0 - 100)
        [Column(TypeName = "decimal(5,2)")]
        public decimal? TotalScorePercent { get; set; }

        // Navigation
        [ForeignKey(nameof(StudentId))]
        public virtual Student Student { get; set; } = null!;

        public virtual ICollection<StudentAssessmentAnswer> Answers { get; set; } = new List<StudentAssessmentAnswer>();
        public virtual ICollection<StudentAssessmentStrandScore> StrandScores { get; set; } = new List<StudentAssessmentStrandScore>();
        public virtual StudentAssessmentResult? Result { get; set; }

        // NEW: Achievements earned during/after this attempt
        public virtual ICollection<StudentAssessmentAchievement> EarnedAchievements { get; set; } = new List<StudentAssessmentAchievement>();
    }
}