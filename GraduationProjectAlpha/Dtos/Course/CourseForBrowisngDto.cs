using GraduationProjectAlpha.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace GraduationProjectAlpha.Dtos.Course
{
    public class CourseForBrowisngDto
    {
        public int CourseId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string TeacherName { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        //public CourseCategory Category { get; set; }
        //public int DurationInMinutes { get; set; }
    }
}
