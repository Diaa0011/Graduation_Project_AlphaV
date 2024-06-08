using GraduationProjectAlpha.Model;

namespace GraduationProjectAlpha.Services.IRepository
{
    public interface IQuizRepository : IBaseRepository<Quiz>
    {
        public Task<Quiz> GetQuizFromCourse(int quizId, int courseId);
    }
}
