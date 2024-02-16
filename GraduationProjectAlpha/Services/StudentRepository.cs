using GraduationProjectAlpha.DbContexts;
using GraduationProjectAlpha.Entities;
using GraduationProjectAlpha.Services.IRepository;
using Microsoft.EntityFrameworkCore;

namespace GraduationProjectAlpha.Services
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _db;
        public StudentRepository(ApplicationDbContext db)
        {
                _db = db;
        }
        public async Task<IEnumerable<Student>> GetStudentsAsync()
        {
            var students = _db.Students.ToListAsync();
            return await students;
        }
        public async Task<Student> GetStudentAsync(int studentId)
        {
            if(studentId == 0)
            {
                throw new NotImplementedException();
            }
            else
            {
                var student = _db.Students.Where(c => c.StudentId == studentId).FirstOrDefaultAsync();
                return await student ;
            }
        }
        public async Task AddStudent(Student student)
        {
            _db.AddAsync(student);
        }
    }
}
