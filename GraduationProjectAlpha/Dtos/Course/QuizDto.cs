using GraduationProjectAlpha.Model;

namespace GraduationProjectAlpha.Dtos.Course
{
    public class QuizDto
    {
        public int QuizId { get; set; }
        public string Title { get; set; } = String.Empty;
        public List<QuestionDto> Questions { get; set; }
    }
}
