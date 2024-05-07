using GraduationProjectAlpha.DbContexts;
using GraduationProjectAlpha.Model;
using GraduationProjectAlpha.Services.IRepository;
using Microsoft.EntityFrameworkCore;

namespace GraduationProjectAlpha.Services
{
    public class CourseRepository : BaseRepository<Course> , ICourseRepository
    {
        private readonly ApplicationDbContext _context;
        public CourseRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Course> GetCourseDetailsAsync(int id)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(c => c.CourseId == id);

            if(course == null)
            {
                return null;
            }
            _context.Entry(course).Collection(c => c.Sections).Load();

            foreach (var section in course.Sections)
            {
                _context.Entry(section).Collection(s => s.Modules).Load();
                
                foreach (var module in section.Modules)
                {
                    _context.Entry(module).Collection(m => m.Lessons).Load();                    
                }
                foreach (var module in section.Modules)
                {
                    _context.Entry(module).Collection(m => m.Quizzes).Load();
                }
            }
            return course;
        }
    }
}
