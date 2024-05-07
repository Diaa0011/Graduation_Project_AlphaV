using GraduationProjectAlpha.Model;

namespace GraduationProjectAlpha.Services.IRepository
{
    public interface ICourseRepository : IBaseRepository<Course>
    {
        public Task<Course> GetCourseDetailsAsync(int id);
    }
}