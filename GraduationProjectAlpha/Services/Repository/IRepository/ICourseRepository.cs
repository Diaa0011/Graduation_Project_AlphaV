using GraduationProjectAlpha.Entities;

namespace GraduationProjectAlpha.Services.Repository.IRepository
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetAllCourses();
    }
}