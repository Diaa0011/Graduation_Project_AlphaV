using GraduationProjectAlpha.Models.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GraduationProjectAlpha.Model
{
        public class CourseEnrollment
        {
            [Key]
            public int CourseEnrollmentId { get; set; }
            public DateTime EnrollmentDate { get; set; }
            [DefaultValue(null)]
            public Rating? Rating { get; set; }
            public Student Student { get; set; }
            public Course Course { get; set; }
        }
}