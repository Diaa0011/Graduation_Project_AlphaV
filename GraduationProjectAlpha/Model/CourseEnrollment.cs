using GraduationProjectAlpha.Models.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraduationProjectAlpha.Model
{
    public class CourseEnrollment
    {
        [Key]
        public int CourseEnrollmentId { get; set; }
        public DateTime EnrollmentDate { get; set; }
        [DefaultValue(null)]
        public Rating? Rating { get; set; }
        [ForeignKey("StudentId")]
        [Required]
        public int StudentId { get; set; }
        public Student Student { get; set; }
        [ForeignKey("CourseId")]
        [Required]
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}