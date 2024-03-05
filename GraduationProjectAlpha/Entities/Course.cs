using GraduationProjectAlpha.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace GraduationProjectAlpha.Entities
{
    public class Course: BaseEntity
    {
       
        public string Name { get; set; }
        public string Description { get; set; }
        public CourseCategory Category{ get; set; }
        public int DurationInMinutes { get; set; }
        public List<CourseEnrollment>? CourseEnrollments { get; set; }
        public List<Section> Sections { get; set; }
    }
}