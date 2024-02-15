using GraduationProjectAlpha.Models.Enums;

namespace GraduationProjectAlpha.Entities
{
    public class CommentVote
    {
        public int CommentVoteId { get; set; }
        public VoteType VoteType { get; set; }
        public Student Student { get; set; }
        public Comment Comment { get; set; }
    }
}