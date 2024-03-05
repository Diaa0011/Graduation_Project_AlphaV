using System.ComponentModel.DataAnnotations;

namespace GraduationProjectAlpha.Entities
{
    public class Comment: BaseEntity
    {
        public string CommentText { get; set; }
        public Student Student { get; set; }
        public Lesson Lesson { get; set; }
        public List<CommentVote>? CommentVotes { get; set; }
    }
}