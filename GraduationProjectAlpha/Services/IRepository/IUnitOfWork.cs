namespace GraduationProjectAlpha.Services.IRepository
{
    public interface IUnitOfWork:IDisposable
    {
        IStudentRepository Students { get; }
        void Save();
    }
}
