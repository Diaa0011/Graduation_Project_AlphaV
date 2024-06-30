using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraduationProjectAlpha.Model
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public string CommentText { get; set; }
        [ForeignKey("StudentId")]
        [Required]
        public int StudentId { get; set; }
        public Student Student { get; set; }
        [ForeignKey("LessonId")]
        [Required]
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
        public List<CommentVote>? CommentVotes { get; set; }
    }
}