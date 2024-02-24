using GraduationProjectAlpha.Model;
using GraduationProjectAlpha.Services.IRepository;
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
        [HttpPost]
        public async Task<ActionResult<Student>> AddStudent(Student student)
        {
            await _unitOfWork.Student.AddStudent(student);
            _unitOfWork.Save();
            return CreatedAtRoute("GetStudent",new Student());

        }
    }
}
