using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GraduationProjectAlpha.Entities
{
    public class StudentLessonInteraction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentLessonId { get; set; }
        public int WatchingTimeInSeconds { get; set; }
        public Lesson Lesson { get; set; }
        public Student Student { get; set; }
    }
}