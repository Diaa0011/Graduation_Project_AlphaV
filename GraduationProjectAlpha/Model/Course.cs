using GraduationProjectAlpha.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace GraduationProjectAlpha.Model
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string TeacherName { get; set; } = string.Empty;
        public string IntroductionVideoUrl { get; set; } = "https://www.youtube.com/watch?v=6O9Z4OB4L6M";
        //public CourseCategory Category { get; set; }
        public List<CourseEnrollment>? CourseEnrollments { get; set; }
        public List<Section> Sections { get; set; } = null!;
    }
}