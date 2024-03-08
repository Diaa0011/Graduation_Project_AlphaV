using GraduationProjectAlpha.Models.Enums;

namespace GraduationProjectAlpha.Dtos.User
{
    public class UserDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string PhoneNumber { get; set; }
        public Sex Sex { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Level Level { get; set; }
    }
}
