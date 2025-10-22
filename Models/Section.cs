using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STRANDVENTURE.Models
{
    public class Section
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty; // e.g., "Grade 11-A", "STEM-1"

        [Required]
        public int GradeLevel { get; set; } // 11, 12, etc.



        public bool IsActive { get; set; } = true;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;



    public virtual ICollection<SectionStudent> SectionStudents { get; set; } = new List<SectionStudent>();
    }
}