using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraduationProjectAlpha.Model
{
    public class Module
    {
        [Key]
        public int ModuleId { get; set; }
        public int Order { get; set; }
        public string Name { get; set; }
        [ForeignKey("SectionId")]
        [Required]
        public int SectionId { get; set; }
        public Section Section { get; set; }
        public List<Lesson> Lessons { get; set; }
        public List<Quiz>? Quizzes { get; set; }
    }
}