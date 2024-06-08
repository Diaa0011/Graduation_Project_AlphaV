using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraduationProjectAlpha.Model
{
    public class Section
    {
        [Key]
        public int SectionId { get; set; }
        public int Order { get; set; }
        public string Name { get; set; }
        [ForeignKey("CourseId")]
        [Required]
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public List<Module> Modules { get; set; }
    }
}