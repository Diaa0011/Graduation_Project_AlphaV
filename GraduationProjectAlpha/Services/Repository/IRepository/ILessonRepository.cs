using GraduationProjectAlpha.Model;

namespace GraduationProjectAlpha.Services.Repository.IRepository
{
    public interface ILessonRepository : IBaseRepository<Lesson>
    {
        public Task<Lesson> GetLessonFromCourseAsync(int lessonId, int courseId);
    }
}