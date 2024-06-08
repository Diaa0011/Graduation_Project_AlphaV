using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraduationProjectAlpha.Model
{
    public class QuizLessonLinking
    {
        [Key]
        public int QuizLessonLinkingId { get; set; }
        [ForeignKey("QuizId")]
        [Required]
        public int QuizId { get; set; }
        public Quiz Quiz { get; set; }
        [ForeignKey("LessonId")]
        [Required]
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
    }
}
