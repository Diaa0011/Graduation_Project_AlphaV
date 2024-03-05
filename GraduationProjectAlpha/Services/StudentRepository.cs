using GraduationProjectAlpha.Data;
using GraduationProjectAlpha.Model;
using GraduationProjectAlpha.Services.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GraduationProjectAlpha.Services
{
    public class StudentRepository : IBaseRepository<Student>, IStudentRepository
    {
        private readonly ApplicationDbContext _db;
        public StudentRepository(ApplicationDbContext db)
        {
                _db = db;
        }

        public Task<Student> AddAsync(Student entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Student>> AddRangeAsync(IEnumerable<Student> entities)
        {
            throw new NotImplementedException();
        }

        public void Attach(Student entity)
        {
            throw new NotImplementedException();
        }

        public void AttachRange(IEnumerable<Student> entities)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync(Expression<Func<Student, bool>> criteria)
        {
            throw new NotImplementedException();
        }

        public void Delete(Student entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteRange(IEnumerable<Student> entities)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Student>> FindAllAsync(Expression<Func<Student, bool>> criteria, string[] includes = null)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Student>> FindAllAsync(Expression<Func<Student, bool>> criteria, int? skip, int? take, Expression<Func<Student, object>> orderBy = null, string orderByDirection = "ASC")
        {
            throw new NotImplementedException();
        }

        public Task<Student> FindAsync(Expression<Func<Student, bool>> criteria, string[] includes = null)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Student>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Student> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Student Update(Student entity)
        {
            throw new NotImplementedException();
        }
        //public async Task<IEnumerable<Student>> GetStudentsAsync()
        //{
        //    var students = _db.Students.ToListAsync();
        //    return await students;
        //}
        //public async Task<Student> GetStudentAsync(int studentId)
        //{
        //    if(studentId == 0)
        //    {
        //        throw new NotImplementedException();
        //    }
        //    else
        //    {
        //        var student = _db.Students.Where(c => c.StudentId == studentId).FirstOrDefaultAsync();
        //        return await student ;
        //    }
        //}
        //public async Task AddStudent(Student student)
        //{
        //    _db.Students.AddAsync(student);
        //}
    }
}
