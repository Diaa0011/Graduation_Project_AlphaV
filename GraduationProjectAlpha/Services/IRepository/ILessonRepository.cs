using GraduationProjectAlpha.Model;

namespace GraduationProjectAlpha.Services.IRepository
{
    public interface ILessonRepository : IBaseRepository<Lesson>
    {
        public Task<Lesson> GetLessonFromCourseAsync(int lessonId, int courseId);
    }
}