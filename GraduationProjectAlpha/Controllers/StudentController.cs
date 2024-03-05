using AutoMapper;
using GraduationProjectAlpha.Dtos.Student;
using GraduationProjectAlpha.Model;
using GraduationProjectAlpha.Services.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProjectAlpha.Controllers
{
    [ApiController]
    [Route("students")]
    public class StudentController:ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public StudentController(IUnitOfWork unitOfWork,IMapper mapper)
        {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
        }
        [HttpGet,Authorize]
        public async Task<IActionResult> GetAllStudents()
        {
            var studentsCatch = await _unitOfWork.Students.GetAllAsync();
            var students = _mapper.Map<IEnumerable<StudentReadDto>>(studentsCatch);
            return Ok(students);
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var student = await _unitOfWork.Students.GetByIdAsync(id);
            return Ok(student);
        }
        [HttpPost]
        public async Task<ActionResult<Student>> AddStudent(Student student)
        {
            await _unitOfWork.Students.AddAsync(student);
            _unitOfWork.Save();
            return CreatedAtRoute("GetStudent",new Student());

        }
    }
}

