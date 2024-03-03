using GraduationProjectAlpha.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace GraduationProjectAlpha.Entities
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        [StringLength(150)]
        [Required]
        public string Name { get; set; }
        [StringLength(400)]
        public string Description { get; set; }
        public string Image { get; set; }
        [Required]
        public CourseCategory Category{ get; set; }
        public List<CourseEnrollment>? CourseEnrollments { get; set; }
        public List<Section> Sections { get; set; }
    }
}