using GraduationProjectAlpha.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace GraduationProjectAlpha.Entities
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }

        [Required]
        [StringLength(50)]
        public string FName { get; set; }

        [Required]
        [StringLength(50)] // Adjust the maximum length as needed
        public string LName { get; set; }

        [Required]
        [MinLength(11)]
        [MaxLength(11)]
        public string PhoneNumber { get; set; }

        [Required]
        public Sex Sex { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public Level Level { get; set; }
        public List<CourseEnrollment>? CourseEnrollments { get; set; }
        public List<StudentLessonInteraction>? StudentLessonInteractions { get; set; }
        public List<StudentQuestionInteraction>? StudentQuestionInteractions { get; set; }
        public List<StudentAssessmentInteraction>? StudentAssessmentInteractions { get; set; }
        public List<Comment>? Comments { get; set; }
        public List<CommentVote>? CommentVotes { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
