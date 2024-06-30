using GraduationProjectAlpha.DbContexts;
using GraduationProjectAlpha.Model;
using GraduationProjectAlpha.Services.Repository.IRepository;

namespace GraduationProjectAlpha.Services.Repository
{
    public class StudentQuizInteractionRepository : BaseRepository<StudentQuizInteraction>, IStudentQuizInteractionRepository
    {
        public readonly ApplicationDbContext _context;
        public StudentQuizInteractionRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        
    }
}
