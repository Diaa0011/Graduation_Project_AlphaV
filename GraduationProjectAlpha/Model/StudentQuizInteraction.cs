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
        public Student Student { get; set; }
        public Quiz Quiz { get; set; }

    }
}