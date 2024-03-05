using GraduationProjectAlpha.DbContexts;
using GraduationProjectAlpha.Model;
using GraduationProjectAlpha.Services.IRepository;

namespace GraduationProjectAlpha.Services
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        private readonly ApplicationDbContext _db;
        public StudentRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
