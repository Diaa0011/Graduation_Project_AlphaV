using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraduationProjectAlpha.Entities
{
    public class AssessmentLessonLinking
    {
        [Key]
        public int AssessmentLessonLinkingId { get; set; }
        public Assessment Assessment { get; set; }
        public Lesson Lesson { get; set; }

    }
}