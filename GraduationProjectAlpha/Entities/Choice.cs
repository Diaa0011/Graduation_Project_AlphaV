namespace GraduationProjectAlpha.Entities
{
    public class Choice
    {
        public int ChoiceId { get; set; }
        public string? ChoiceText { get; set; }
        public string? ChoiceImageUrl { get; set; }
        public int Order { get; set; }
        public Question Question { get; set; }
    }
}