using System.ComponentModel.DataAnnotations;

namespace GraduationProjectAlpha.Entities
{
    public class Lesson
    {
        [Key]
        public int LessonId { get; set; }
        public string Name { get; set; }
        public string VideoUrl { get; set; }
        public string PdfUrl { get; set; }
        public string Description { get; set; }
        public int DurationInSeconds { get; set; }
        public int Order { get; set; }
        public Module Module { get; set; }
        public List<AssessmentLessonLinking>? AssessmentLessonLinkings { get; set; }
        public List<Comment>? Comments { get; set; }
        public List<StudentLessonInteraction>? StudentLessonInteractions { get; set; }
    }
}