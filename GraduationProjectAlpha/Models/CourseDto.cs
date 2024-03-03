using GraduationProjectAlpha.Models.Enums;

namespace GraduationProjectAlpha.Models
{
    public class CourseDto
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public CourseCategory Category { get; set; }
        public string TeacherName { get; set; }
    }
}
