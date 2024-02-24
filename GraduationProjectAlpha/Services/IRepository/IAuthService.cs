using GraduationProjectAlpha.Model;

namespace GraduationProjectAlpha.Services.IRepository
{
    public interface IAuthRepository
    {
        Task<bool> Login(User user);
        Task<bool> Register(User user);
        string GenerateToken(User user);
    }
}
