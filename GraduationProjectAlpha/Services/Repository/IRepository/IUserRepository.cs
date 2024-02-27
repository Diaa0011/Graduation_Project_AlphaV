using GraduationProjectAlpha.Entities;

namespace GraduationProjectAlpha.Services.Repository.IRepository
{
    public interface IUserRepository
    {
        Task AddUserAsync(User user);
        Task<User> FindUserByEmailAsync(string email);
    }
}