using System.ComponentModel.DataAnnotations;

namespace GraduationProjectAlpha.Model
{
    public class Module
    {
        [Key]
        public int ModuleId { get; set; }
        public int Order { get; set; }
        public string Name { get; set; }
        public int DurationInMinutes { get; set; }
        public Section Section { get; set; }
        public List<Lesson> Lessons { get; set; }
        public List<Assessment>? Assessments { get; set; }
    }
}