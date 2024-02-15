using GraduationProjectAlpha.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace GraduationProjectAlpha.Entities
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Sex Sex { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Level Level { get; set; }
        public List<CourseEnrollment> CourseEnrollments { get; set; }
        public List<StudentLessonInteraction> StudentLessonInteractions { get; set; }
        public List<Comment> Comments { get; set; }
        public List<CommentVote> CommentVotes { get; set; }
        
    }
}
