using GraduationProjectAlpha.Model.Enums;
using System.ComponentModel.DataAnnotations;

namespace GraduationProjectAlpha.Dtos.Student
{
    public class StudentCreateDto
    {
        [Required]
        public string FName { get; set; }
        [Required]
        public string LName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        public string Password { get; set; }
        public Sex Sex { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Level Level { get; set; }
    }
}
