using GraduationProjectAlpha.Dtos.User;
using GraduationProjectAlpha.Model;

namespace GraduationProjectAlpha.Services.IRepository
{
    public interface IAuthRepository
    {
        Task<bool> Login(LoginUserDto user);
        Task<bool> Register(UserDto user);
        string GenerateToken(LoginUserDto user);
    }
}
