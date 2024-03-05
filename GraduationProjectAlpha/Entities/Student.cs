using GraduationProjectAlpha.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraduationProjectAlpha.Entities
{
    public class Student: BaseEntity
    {
    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    public int StudentId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Sex Sex { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Level Level { get; set; }
        public List<CourseEnrollment>? CourseEnrollments { get; set; }
        public List<StudentLessonInteraction>? StudentLessonInteractions { get; set; }
        public List<StudentQuestionInteraction>? StudentQuestionInteractions { get; set; }
        public List<StudentAssessmentInteraction>? StudentAssessmentInteractions { get; set; }
        public List<Comment>? Comments { get; set; }
        public List<CommentVote>? CommentVotes { get; set; }
        
    }
}
