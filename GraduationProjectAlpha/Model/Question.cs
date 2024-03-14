using GraduationProjectAlpha.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace GraduationProjectAlpha.Model
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; } 
        public string? ImageUrl { get; set; }
        public string QuestionText { get; set; } = string.Empty;
        public int RightChoiceId { get; set; }
        public int Grade { get; set; }
        public int Order { get; set; }
        public QuestionType QuestionType { get; set; }
        public List<Choice> Choices { get; set; } =  new List<Choice>();
        public List<StudentQuestionInteraction>? StudentQuestionInteractions { get; set; }

    }
}