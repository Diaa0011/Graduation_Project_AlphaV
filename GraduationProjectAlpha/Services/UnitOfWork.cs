using GraduationProjectAlpha.DbContexts;
using GraduationProjectAlpha.Services.IRepository;

namespace GraduationProjectAlpha.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public IStudentRepository Student { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Student = new StudentRepository(_db);
        }
        public void Save()
        {
          _db.SaveChangesAsync();
        }
    }
}
