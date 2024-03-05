using System.ComponentModel.DataAnnotations;

namespace GraduationProjectAlpha.Model
{
    public class AssessmentLessonLinking: BaseEntity
    {
     
        public Assessment Assessment { get; set; }
        public Lesson Lesson { get; set; }
    }
}
