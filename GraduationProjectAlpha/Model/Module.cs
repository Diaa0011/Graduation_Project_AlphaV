using System.ComponentModel.DataAnnotations;

namespace GraduationProjectAlpha.Model
{
    public class Module:BaseEntity
    {

        public int Order { get; set; }
        public string Name { get; set; }
        public int DurationInMinutes { get; set; }
        public Section Section { get; set; }
        public List<Lesson> Lessons { get; set; }
        public List<Assessment>? Assessments { get; set; }
    }
}