namespace GraduationProjectAlpha.Entities
{
    public class StudentLessonInteraction
    {
        public int StudentLessonId { get; set; }
        public int WatchingTimeInSeconds { get; set; }
        public Lesson Lesson { get; set; }
        public Student Student { get; set; }
    }
}