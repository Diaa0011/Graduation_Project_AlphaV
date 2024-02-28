using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GraduationProjectAlpha.Models
{
    public class UserLoginDto
    {
        [EmailAddress]
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        [PasswordPropertyText]
        [MinLength(8)]
        public string Password { get; set; }
    }
}
