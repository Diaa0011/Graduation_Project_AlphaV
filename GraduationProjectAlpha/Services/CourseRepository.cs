using GraduationProjectAlpha.DbContexts;
using GraduationProjectAlpha.Model;
using GraduationProjectAlpha.Services.IRepository;

namespace GraduationProjectAlpha.Services
{
    public class CourseRepository : BaseRepository<Course> , ICourseRepository
    {
        private readonly ApplicationDbContext _context;
        public CourseRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
