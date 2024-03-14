using System.ComponentModel.DataAnnotations;

namespace GraduationProjectAlpha.Model
{
    public class QuizLessonLinking
    {
        [Key]
        public int QuizLessonLinkingId { get; set; }
        public Quiz Quiz { get; set; }
        public Lesson Lesson { get; set; }
    }
}
