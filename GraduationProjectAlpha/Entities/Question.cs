using GraduationProjectAlpha.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace GraduationProjectAlpha.Entities
{
    public class Question: BaseEntity
    {

        public QuestionCategory QuestionCategory { get; set; }
        public string? ImageUrl { get; set; }
        public string QuestionText { get; set; }
        public int RightChoiceIndex { get; set; }
        public QuestionType QuestionType { get; set; }
        public List<Choice> Choices { get; set; }
        public List<StudentQuestionInteraction>? StudentQuestionInteractions { get; set; }
        public List<AssessmentQuestion>? AssessmentQuestions { get; set; }
        
    }
}