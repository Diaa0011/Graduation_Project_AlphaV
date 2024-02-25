using GraduationProjectAlpha.Models.Enums;

namespace GraduationProjectAlpha.Dtos.Student
{
    public class StudentReadDto
    {
        public int StudentId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Sex Sex { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Level Level { get; set; }
    }
}
