using GraduationProjectAlpha.Entities;
using System.Collections.ObjectModel;

namespace GraduationProjectAlpha.Services.Repository.IRepository
{
    public interface IStudentRepository
    {
        Task<Student> GetStudentAsync(int studentId);
        Task<IEnumerable<Student>> GetStudentsAsync();
        Task AddStudentAsync(Student student);


    }
}
