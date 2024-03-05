using GraduationProjectAlpha.Model.Enums;

namespace GraduationProjectAlpha.Model
{
    public class User
    {
        public string Email { get; set; }
        public string Password { get;set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string PhoneNumber { get; set; }
        public Sex Sex { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Level Level { get; set; }

    }
}
