using GraduationProjectAlpha.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace GraduationProjectAlpha.Model
{
    public class CourseEnrollment
    {
        [Key]
        public int CourseEnrollmentId { get; set; }
        public DateTime EnrolmentDate { get; set; }
        public Rating? Rating { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}