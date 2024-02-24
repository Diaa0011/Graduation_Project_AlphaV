using GraduationProjectAlpha.Model;
using System.Collections.ObjectModel;

namespace GraduationProjectAlpha.Services.IRepository
{
    public interface IStudentRepository
    {
        Task<Student> GetStudentAsync(int studentId);
        Task<IEnumerable<Student>> GetStudentsAsync();
        Task AddStudent(Student student);


    }
}
