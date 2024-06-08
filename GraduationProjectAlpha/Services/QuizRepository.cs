using GraduationProjectAlpha.DbContexts;
using GraduationProjectAlpha.Model;
using GraduationProjectAlpha.Services.IRepository;
using Microsoft.EntityFrameworkCore;

namespace GraduationProjectAlpha.Services
{
    public class QuizRepository : BaseRepository<Quiz>, IQuizRepository
    {
        public readonly ApplicationDbContext _context;
        public QuizRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Quiz> GetQuizFromCourse(int quizId, int courseId)
        {
            var quiz = await _context.Quizzes
                .Include(q => q.Module)
                .ThenInclude(m => m.Section)
                .ThenInclude(s => s.Course)
                .Include(q => q.Questions)
                .ThenInclude(q => q.Choices)
                .FirstOrDefaultAsync(q => q.QuizId == quizId)
                ;

            if (quiz == null) return null;
            if (quiz.Module.Section.Course.CourseId != quizId) return null;
            return quiz;
        }
    }
}
