using GraduationProjectAlpha.DbContexts;
using GraduationProjectAlpha.Model;
using GraduationProjectAlpha.Services.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace GraduationProjectAlpha.Services.Repository
{
    public class LessonRepository : BaseRepository<Lesson>, ILessonRepository
    {
        private readonly ApplicationDbContext _context;
        public LessonRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Lesson> GetLessonFromCourseAsync(int lessonId, int courseId)
        {
            var lesson = await _context.Lessons
                .Include(l => l.Module)
                .ThenInclude(m => m.Section)
                .ThenInclude(s => s.Course)
                .FirstOrDefaultAsync(l => l.LessonId == lessonId);

            if (lesson == null) return null;

            var courseIdFromLesson = lesson.Module.Section.Course.CourseId;

            if (courseIdFromLesson != courseId) return null;

            return lesson;
        }
    }
}