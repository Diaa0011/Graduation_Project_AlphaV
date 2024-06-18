using GraduationProjectAlpha.DbContexts;
using GraduationProjectAlpha.Model;
using GraduationProjectAlpha.Services.Repository.IRepository;

namespace GraduationProjectAlpha.Services.Repository
{
    public class StudentQuestionInteractionRepository : BaseRepository<StudentQuestionInteraction>, IStudentQuestionInteractionRepository
    {
        private readonly ApplicationDbContext _context;
        public StudentQuestionInteractionRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
