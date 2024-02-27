using System.Text.RegularExpressions;

namespace GraduationProjectAlpha.Services
{
    public class EmailCheckerService
    {
        public bool IsEmailValid(string email)
        {
            // Regular expression pattern for email validation
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            // Check if the email matches the pattern
            return Regex.IsMatch(email, emailPattern);
        }
    }
}
