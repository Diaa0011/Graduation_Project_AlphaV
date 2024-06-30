namespace GraduationProjectAlpha.Dtos.Course
{
    public class LessonDto
    {
        public int LessonId { get; set; }
        public string Name { get; set; }
        public string VideoUrl { get; set; }
        public string PdfUrl { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
    }
}
