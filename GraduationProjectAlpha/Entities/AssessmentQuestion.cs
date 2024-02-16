using System.ComponentModel.DataAnnotations;

namespace GraduationProjectAlpha.Entities
{
    public class AssessmentQuestion
    {
        [Key]
        public int AssessmentQuestionId { get; set; }
        public int Grade { get; set; }
        public int Order { get; set; }
        public Question Question { get; set; }
        public Assessment Assessment { get; set; }
    }
}