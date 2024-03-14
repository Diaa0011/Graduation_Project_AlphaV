using GraduationProjectAlpha.DbContexts;
using GraduationProjectAlpha.Model;
using GraduationProjectAlpha.Services.IRepository;

namespace GraduationProjectAlpha.Services
{
    public class CourseEnrollmentRepository : BaseRepository<CourseEnrollment>, ICourseEnrollmentRepository
    {
        public readonly ApplicationDbContext _context;
        public CourseEnrollmentRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
