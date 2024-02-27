namespace GraduationProjectAlpha.Services.PasswordChecker
{
    public class PasswordCheckerService
    {
        public PasswordRequirements PasswordRequirements { get; set; }

        public PasswordCheckerService()
        {
            PasswordRequirements = new PasswordRequirements()
            {
                RequiredLength = 8,
                RequiredUniqueChars = 1,
                RequireDigit = true,
                RequireLowercase = true,
                RequireNonAlphanumeric = true,
                RequireUppercase = true

            };
        }
        public bool IsPasswordValid(string password)
        {
            return PasswordRequirements.IsMatch(password);
        }
    }
}
