using GraduationProjectAlpha.Services.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProjectAlpha.Controllers
{
    [ApiController]
    [Route("students")]
    public class StudentController:ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public StudentController(IUnitOfWork unitOfWork)
        {
                _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _unitOfWork.Student.GetStudentsAsync();
            return Ok(students);
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var student = await _unitOfWork.Student.GetStudentAsync(id);
            return Ok(student);
        }
        
        //public async Task AddStudent(Student student)
        //{
        //    _unitOfWork.Student.Add(student);

        //}
    }
}
