using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STRANDVENTURE.Models
{
    public class QuestionOptionStrandWeight
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid QuestionOptionId { get; set; }

        [Required]
        public Guid StrandId { get; set; }

        [Required]
        [Column(TypeName = "decimal(3,2)")]
        [Range(0.00, 1.00)]
        public decimal Weight { get; set; } // 0.00 to 1.00

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        [ForeignKey("QuestionOptionId")]
        public virtual QuestionOption QuestionOption { get; set; } = null!;

        [ForeignKey("StrandId")]
        public virtual Strand Strand { get; set; } = null!;
    }
}