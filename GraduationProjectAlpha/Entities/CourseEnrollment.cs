using GraduationProjectAlpha.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace GraduationProjectAlpha.Entities
{
    public class CourseEnrollment: BaseEntity
    {
        
        public DateTime EnrolmentDate { get; set; }
        public Rating? Rating { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}