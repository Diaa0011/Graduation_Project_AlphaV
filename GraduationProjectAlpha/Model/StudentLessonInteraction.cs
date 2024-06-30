using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GraduationProjectAlpha.Model
{
    public class StudentLessonInteraction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentLessonId { get; set; }
        [ForeignKey("LessonId")]
        [Required]
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
        [ForeignKey("StudentId")]
        [Required]
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}