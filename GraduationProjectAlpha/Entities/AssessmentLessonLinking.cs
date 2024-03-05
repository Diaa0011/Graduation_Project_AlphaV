using System.ComponentModel.DataAnnotations;

namespace GraduationProjectAlpha.Entities
{
    public class AssessmentLessonLinking: BaseEntity
    {
     
        public Assessment Assessment { get; set; }
        public Lesson Lesson { get; set; }
    }
}
