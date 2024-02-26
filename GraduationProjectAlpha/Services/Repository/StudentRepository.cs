using GraduationProjectAlpha.DbContexts;
using GraduationProjectAlpha.Entities;
using GraduationProjectAlpha.Services.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace GraduationProjectAlpha.Services.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public StudentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Student>> GetStudentsAsync()
        {
            var students = _dbContext.Students.ToListAsync();
            return await students;
        }
        public async Task<Student> GetStudentAsync(int studentId)
        {
            if (studentId == 0)
            {
                throw new NotImplementedException();
            }
            else
            {
                var student = _dbContext.Students.Where(c => c.StudentId == studentId).FirstOrDefaultAsync();
                return await student;
            }
        }
        public async Task AddStudent(Student student)
        {
            await _dbContext.Students.AddAsync(student);
            await _dbContext.SaveChangesAsync();
        }
    }
}
