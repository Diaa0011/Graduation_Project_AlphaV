using GraduationProjectAlpha.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace GraduationProjectAlpha.Entities
{
    public class Assessment
    {
        [Key]
        public int AssessmentId { get; set; }
        public AssessmentType AssessmentType { get; set; }
        public List<AssessmentLessonLinking>? AssessmentLessonLinkings { get; set; }
        public string Title { get; set; }
        public int Grade { get; set; }
        public List<AssessmentQuestion> AssessmentQuestions { get; set; }
        public List<StudentAssessmentInteraction>? StudentAssessmentInteractions { get; set; }
        public Module Module { get; set; }
    }
}
