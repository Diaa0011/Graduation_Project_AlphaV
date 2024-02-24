using System.ComponentModel.DataAnnotations;

namespace GraduationProjectAlpha.Model
{
    public class AssessmentLessonLinking
    {
        [Key]
        public int AssessmentLessonLinkingId { get; set; }
        public Assessment Assessment { get; set; }
        public Lesson Lesson { get; set; }
    }
}
