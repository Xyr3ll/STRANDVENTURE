using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STRANDVENTURE.Models
{
    public class StudentAssessmentStrandScore
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid AttemptId { get; set; }

        [Required]
        public Guid StrandId { get; set; }

        // Aggregate score for the strand (0 - 100)
        [Required]
        [Column(TypeName = "decimal(5,2)")]
        [Range(0, 100)]
        public decimal ScorePercent { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        [ForeignKey(nameof(AttemptId))]
        public virtual StudentAssessmentAttempt Attempt { get; set; } = null!;

        [ForeignKey(nameof(StrandId))]
        public virtual Strand Strand { get; set; } = null!;
    }
}