using GraduationProjectAlpha.DbContexts;
using GraduationProjectAlpha.Model;
using GraduationProjectAlpha.Services.IRepository;
using Microsoft.EntityFrameworkCore;

namespace GraduationProjectAlpha.Services
{
    public class CourseEnrollmentRepository : BaseRepository<CourseEnrollment>, ICourseEnrollmentRepository
    {
        public readonly ApplicationDbContext _context;
        public CourseEnrollmentRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task EnrollAsync(int studentId, int courseId)
        {
            var existingEnrollment = await _context.CourseEnrollments
                .Include(e => e.Student)
                .Include(e => e.Course)
                .Select(e => new { e.Student.StudentId, e.Course.CourseId })
                .FirstOrDefaultAsync(p => p.StudentId == studentId && p.CourseId == courseId);

            if (existingEnrollment != null) return;

            var course = _context.Courses.FirstOrDefault(c => c.CourseId == courseId);

            if(course == null) return; 

            var student = _context.Students.FirstOrDefault(s => s.StudentId == studentId);

            var courseEnrollment = new CourseEnrollment()
            {
                Course = course,
                Student = student
            };
            _context.CourseEnrollments.Add(courseEnrollment);
            await _context.SaveChangesAsync();
        }

        public double CalculateCourseAvgRating(int courseId)
        {
            var course = _context.Courses.FirstOrDefaultAsync(c => c.CourseId == courseId);
            
            if (course == null) return -1;

            var avgRating = (double) _context.CourseEnrollments
                .Where(e => e.Rating.HasValue)
                .Average(e => (double) e.Rating.Value);

            avgRating = Math.Round(avgRating, 1);

            return avgRating;
        }
    }
}
