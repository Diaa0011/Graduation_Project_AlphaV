namespace GraduationProjectAlpha.Services.PasswordChecker
{
    public class PasswordRequirements
    {
        public int RequiredLength { get; set; }
        public int RequiredUniqueChars { get; set; }
        public bool RequireNonAlphanumeric { get; set; }
        public bool RequireLowercase { get; set; }
        public bool RequireUppercase { get; set; }
        public bool RequireDigit { get; set; }

        public bool IsMatch(string password)
        {
            if (password == null) return false;

            if (password.Length < RequiredLength)
                return false;

            if (password.Distinct().Count() < RequiredUniqueChars)
                return false;

            if (RequireNonAlphanumeric && password.All(char.IsLetterOrDigit))
                return false;

            if (RequireLowercase && !password.Any(char.IsLower))
                return false;

            if (RequireUppercase && !password.Any(char.IsUpper))
                return false;

            if (RequireDigit && !password.Any(char.IsDigit))
                return false;

            return true;
        }
    }
}