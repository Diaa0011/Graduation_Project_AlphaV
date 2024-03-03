namespace GraduationProjectAlpha.Services.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IStudentRepository Student { get; }
        IUserRepository User { get; }
        ICourseRepository Course { get; }
        Task SaveAsync();
    }
}
