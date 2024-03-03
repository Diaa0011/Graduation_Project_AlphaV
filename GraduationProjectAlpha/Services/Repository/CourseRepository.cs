using GraduationProjectAlpha.DbContexts;
using GraduationProjectAlpha.Entities;
using GraduationProjectAlpha.Services.Repository.IRepository;

namespace GraduationProjectAlpha.Services.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _context;

        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Course> GetAllCourses()
        {
            return _context.Courses.ToList();
        }
    }
}
