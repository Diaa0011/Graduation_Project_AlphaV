using GraduationProjectAlpha.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace GraduationProjectAlpha.Model
{
    public class Quiz
    {
        [Key]
        public int QuizId { get; set; }
        public string Title { get; set; } = String.Empty;
        public int Order { get; set; }
        public List<QuizLessonLinking>? QuizLessonLinkings { get; set; }
        public List<StudentQuizInteraction>? StudentQuizInteractions { get; set; }
        public Module Module { get; set; } = null!;
    }
}
