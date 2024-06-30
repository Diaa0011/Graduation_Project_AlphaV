using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraduationProjectAlpha.Model
{
    public class StudentQuizInteraction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentQuizId { get; set; }
        public int OverallGrade { get; set; }
        [ForeignKey("StudentId")]
        [Required]
        public int StudentId { get; set; }
        public Student Student { get; set; }
        [ForeignKey("QuizId")]
        [Required]
        public int QuizId { get; set; }
        public Quiz Quiz { get; set; }

    }
}