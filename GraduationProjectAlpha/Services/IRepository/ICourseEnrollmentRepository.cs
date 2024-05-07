using GraduationProjectAlpha.Model;

namespace GraduationProjectAlpha.Services.IRepository
{
    public interface ICourseEnrollmentRepository : IBaseRepository<CourseEnrollment>
    {
        public double CalculateCourseAvgRating(int courseId);
        public Task EnrollAsync(int studentId, int courseId);
    }
}
