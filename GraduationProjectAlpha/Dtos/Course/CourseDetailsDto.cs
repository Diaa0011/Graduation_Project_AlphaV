namespace GraduationProjectAlpha.Dtos.Course
{
    public class CourseDetailsDto
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public double RatingAverage { get; set; }
        public string Description { get; set; }
        public string IntroductionVideoUrl { get; set; }
        public string TeacherName { get; set; }
        public bool IsEnrolled { get; set; }
        public List<SectionDto> SectionDtos { get; set; }
    }
}
