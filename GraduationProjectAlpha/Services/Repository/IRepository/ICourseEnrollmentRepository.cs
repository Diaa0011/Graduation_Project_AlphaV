using GraduationProjectAlpha.Model;

namespace GraduationProjectAlpha.Services.Repository.IRepository
{
    public interface ICourseEnrollmentRepository : IBaseRepository<CourseEnrollment>
    {
        public Task<double> CalculateCourseAvgRatingAsync(int courseId);
        public Task EnrollAsync(int studentId, int courseId);
    }
}
