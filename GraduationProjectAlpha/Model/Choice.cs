using System.ComponentModel.DataAnnotations;

namespace GraduationProjectAlpha.Model
{
    public class Choice: BaseEntity
    {
       
        public string? ChoiceText { get; set; }
        public string? ChoiceImageUrl { get; set; }
        public int Order { get; set; }
        public Question Question { get; set; }
    }
}