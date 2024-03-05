using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraduationProjectAlpha.Model
{
    public class StudentAssessmentInteraction: BaseEntity
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int StudentAssessmentId { get; set; }
        public int OverallGrade { get; set; }
        public Student Student { get; set; }
        public Assessment Assessment { get; set; }

    }
}