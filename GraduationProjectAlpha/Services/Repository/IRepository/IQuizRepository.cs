using GraduationProjectAlpha.Model;

namespace GraduationProjectAlpha.Services.Repository.IRepository
{
    public interface IQuizRepository : IBaseRepository<Quiz>
    {
        public Task<Quiz> GetQuizFromCourse(int quizId, int courseId);
    }
}
