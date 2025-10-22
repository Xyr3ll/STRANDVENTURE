using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STRANDVENTURE.Models
{
    public class StudentAssessmentAnswer
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid AttemptId { get; set; }

        [Required]
        public Guid QuestionId { get; set; }

        [Required]
        public Guid QuestionOptionId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime SelectedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        [ForeignKey(nameof(AttemptId))]
        public virtual StudentAssessmentAttempt Attempt { get; set; } = null!;

        [ForeignKey(nameof(QuestionId))]
        public virtual Question Question { get; set; } = null!;

        [ForeignKey(nameof(QuestionOptionId))]
        public virtual QuestionOption QuestionOption { get; set; } = null!;
    }
}