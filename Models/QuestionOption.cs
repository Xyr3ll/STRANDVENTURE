using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STRANDVENTURE.Models
{
    public class QuestionOption
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid QuestionId { get; set; }

        [Required]
        [StringLength(300)]
        public string OptionText { get; set; } = string.Empty;

        [Required]
        [StringLength(1)]
        public string OptionLetter { get; set; } = string.Empty; // 'A', 'B', 'C', 'D'

        // Marks the correct answer for the question. Enforced via model builder to have only 1 per Question.
        public bool IsCorrect { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        [ForeignKey("QuestionId")]
        public virtual Question Question { get; set; } = null!;

        public virtual ICollection<QuestionOptionStrandWeight> QuestionOptionStrandWeights { get; set; } = new List<QuestionOptionStrandWeight>();
    }
}