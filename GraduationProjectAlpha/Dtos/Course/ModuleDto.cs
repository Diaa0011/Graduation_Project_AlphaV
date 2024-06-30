using GraduationProjectAlpha.Model;

namespace GraduationProjectAlpha.Dtos.Course
{
    public class ModuleDto
    {
        public int ModuleId { get; set; }
        public string ModuleName { get; set; }
        public int Order { get; set; }
        public List<LessonForCourseTreeDto> LessonDtos { get; set; }
        public List<QuizForCourseTreeDto> QuizDtos { get; set; }
    }
}