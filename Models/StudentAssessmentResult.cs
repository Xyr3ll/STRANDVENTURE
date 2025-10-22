using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STRANDVENTURE.Models
{
    // One honored result per student. Points to the attempt that is honored.
    public class StudentAssessmentResult
    {
        // Stores the random feedback description for the recommended strand
        [StringLength(300)]
        public string? FeedbackDescription { get; set; }
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid StudentId { get; set; }

        [Required]
        public Guid AttemptId { get; set; }

        // Optional recommended strand outcome
        public Guid? RecommendedStrandId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime FinalizedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        [ForeignKey(nameof(StudentId))]
        public virtual Student Student { get; set; } = null!;

        [ForeignKey(nameof(AttemptId))]
        public virtual StudentAssessmentAttempt Attempt { get; set; } = null!;

        [ForeignKey(nameof(RecommendedStrandId))]
        public virtual Strand? RecommendedStrand { get; set; }
    }
}