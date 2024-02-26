using GraduationProjectAlpha.Entities;

namespace GraduationProjectAlpha.Services.Repository.IRepository
{
    public interface IUserRepository
    {
        Task AddUser(User user);
    }
}