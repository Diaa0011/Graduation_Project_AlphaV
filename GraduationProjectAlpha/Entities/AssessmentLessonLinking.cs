namespace GraduationProjectAlpha.Entities
{
    public class AssessmentLessonLinking
    {
        public int AssessmentLessonLinkingId { get; set; }
        public Assessment Assessment { get; set; }
        public Lesson Lesson { get; set; }

    }
}