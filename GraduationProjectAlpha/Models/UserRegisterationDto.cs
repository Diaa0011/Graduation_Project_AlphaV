using GraduationProjectAlpha.Models.Enums;

namespace GraduationProjectAlpha.Models
{
    public class UserRegisterationDto
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public Sex Sex { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Username { get; set; }
        public DateTime DateOfBith { get; set; } = new DateTime(2002, 3, 28);
        public Level Level { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
    }
}
