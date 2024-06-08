using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraduationProjectAlpha.Model
{
    public class Choice
    {
        [Key]
        public int ChoiceId { get; set; }
        public string? ChoiceText { get; set; }
        public string? ChoiceImageUrl { get; set; }
        public int Order { get; set; }
        [ForeignKey("QuestionId")]
        [Required]
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}