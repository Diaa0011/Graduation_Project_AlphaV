using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GraduationProjectAlpha.Models
{
    public class UserLoginDto
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        [PasswordPropertyText]
        public string Password { get; set; }
    }
}
