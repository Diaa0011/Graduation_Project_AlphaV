using GraduationProjectAlpha.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace GraduationProjectAlpha.Entities
{
    public class CommentVote: BaseEntity
    {
       
        public VoteType VoteType { get; set; }
        public Student Student { get; set; }
        public Comment Comment { get; set; }
    }
}