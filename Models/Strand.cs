using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STRANDVENTURE.Models
{
    public class Strand
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [StringLength(200)]
        public string? Description { get; set; }

        public bool IsActive { get; set; } = true;

        [StringLength(20)]
        [Required]
        public string Color { get; set; } = "#000000"; // Hex color (seed data overrides)

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        public virtual ICollection<QuestionOptionStrandWeight> QuestionOptionStrandWeights { get; set; } = new List<QuestionOptionStrandWeight>();
    }
}