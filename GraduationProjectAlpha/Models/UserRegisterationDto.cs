using GraduationProjectAlpha.Models.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GraduationProjectAlpha.Models
{
    public class UserRegisterationDto
    {
        [MaxLength(50)]
        [Required]
        public string FName { get; set; }

        [MaxLength(50)]
        [Required]
        public string LName { get; set; }

        [Required]
        public Sex? Sex { get; set; }

        [EmailAddress]
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [MaxLength(50)]
        [Required]
        public string Username { get; set; }

        [Required]
        public DateTime? DateOfBith { get; set; }

        [Required]
        public Level? Level { get; set; }

        [Required]
        [PasswordPropertyText]
        [MinLength(8)]
        public string Password { get; set; }

        [Required]
        [PasswordPropertyText]
        [MinLength(8)]
        public string PasswordConfirmation { get; set; }

    }
}
