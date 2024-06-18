using GraduationProjectAlpha.Model;
using GraduationProjectAlpha.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraduationProjectAlpha.Dtos.Course
{
    public class QuestionWithStudentAnswerDto
    {
        public int QuestionId { get; set; }
        public string? ImageUrl { get; set; }
        public string QuestionText { get; set; } = string.Empty;
        public int Order { get; set; }
        public int? StudentChoiceId { get; set; }
        public int RightChoiceId { get; set; }
        public StudentChoiceStatus ChoiceStatus { get; set; } = StudentChoiceStatus.Missing;
        public List<ChoiceDto> Choices { get; set; }
    }
}