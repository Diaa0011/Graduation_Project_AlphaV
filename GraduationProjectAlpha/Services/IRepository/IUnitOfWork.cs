namespace GraduationProjectAlpha.Services.IRepository
{
    public interface IUnitOfWork
    {
        IStudentRepository Student { get; }
        void Save();
    }
}
