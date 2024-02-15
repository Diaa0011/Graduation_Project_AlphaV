namespace GraduationProjectAlpha.Entities
{
    public class StudentAssessmentInteraction
    {
        public int StudentAssessmentId { get; set; }
        public int OverallGrade { get; set; }
        public Student Student { get; set; }
        public Assessment Assessment { get; set; }

    }
}