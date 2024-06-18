using GraduationProjectAlpha.Model;

namespace GraduationProjectAlpha.Dtos.Course
{
    public class QuizReportDto
    {
        public int QuizId { get; set; }
        public string Title { get; set; } = String.Empty;
        public List<QuestionWithStudentAnswerDto> Questions { get; set; }
    }
}
