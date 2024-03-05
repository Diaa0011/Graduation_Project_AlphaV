using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using GraduationProjectAlpha.Model.Enums;

namespace GraduationProjectAlpha.Model
{
    public class StudentQuestionInteraction: BaseEntity
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int StudentQuestionId { get; set; }
        public int? StudentChoiceIndex { get; set; }
        public StudentChoiceStatus StudentChoiceStatus { get; set; }
        public Question Question { get; set; }
        public Student Student { get; set; }
    }
}