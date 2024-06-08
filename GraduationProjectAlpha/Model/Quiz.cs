using GraduationProjectAlpha.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public List<Question> Questions { get; set; }
        [ForeignKey("ModuleId")]
        [Required]
        public int ModuleId { get; set; }
        public Module Module { get; set; } = null!;
    }
}
