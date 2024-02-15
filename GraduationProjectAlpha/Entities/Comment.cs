namespace GraduationProjectAlpha.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string CommentText { get; set; }
        public Student Student { get; set; }
        public Lesson Lesson { get; set; }
        public List<CommentVote>? CommentVotes { get; set; }
    }
}