using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using GraduationProjectAlpha.Models.Enums;

namespace GraduationProjectAlpha.Model
{
    public class StudentQuestionInteraction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentQuestionId { get; set; }
        public int? StudentChoiceId { get; set; }
        public StudentChoiceStatus StudentChoiceStatus { get; set; }
        [ForeignKey("QuestionId")]
        [Required]
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        [ForeignKey("StudentId")]
        [Required]
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}