using GraduationProjectAlpha.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraduationProjectAlpha.Model
{
    public class CommentVote
    {
        [Key]
        public int CommentVoteId { get; set; }
        public VoteType VoteType { get; set; }
        [ForeignKey("StudentId")]
        [Required]
        public int StudentId { get; set; }
        public Student Student { get; set; }
        [ForeignKey("CommentId")]
        [Required]
        public int CommentId { get; set; }
        public Comment Comment { get; set; }
    }
}