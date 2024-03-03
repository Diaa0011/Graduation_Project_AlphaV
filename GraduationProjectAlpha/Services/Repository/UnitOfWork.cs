using GraduationProjectAlpha.DbContexts;
using GraduationProjectAlpha.Services.Repository.IRepository;

namespace GraduationProjectAlpha.Services.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        public IStudentRepository Student { get; }
        public IUserRepository User { get; }
        public ICourseRepository Course { get; }

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            Student = new StudentRepository(_dbContext);
            User = new UserRepository(_dbContext);
            Course = new CourseRepository(_dbContext);
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
