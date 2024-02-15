using GraduationProjectAlpha.Models.Enums;

namespace GraduationProjectAlpha.Entities
{
    public class CourseEnrollment
    {
        public int CourseEnrollmentId { get; set; }
        public DateTime EnrolmentDate { get; set; }
        public Rating? Rating { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}