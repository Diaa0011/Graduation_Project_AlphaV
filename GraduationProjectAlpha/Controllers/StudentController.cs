using AutoMapper;
using GraduationProjectAlpha.Dtos.Course;
using GraduationProjectAlpha.Dtos.Student;
using GraduationProjectAlpha.Model;
using GraduationProjectAlpha.Services.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;

namespace GraduationProjectAlpha.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController:ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public StudentController(IUnitOfWork unitOfWork,IMapper mapper)
        {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var studentsCatch = await _unitOfWork.Student.GetAllAsync();
            var students = _mapper.Map<IEnumerable<StudentReadDto>>(studentsCatch);
            return Ok(students);
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var student = await _unitOfWork.Student.GetByIdAsync(id);
            return Ok(student);
        }
        [HttpPost]
        public async Task<ActionResult<Student>> AddStudent(Student student)
        {
            await _unitOfWork.Student.AddAsync(student);
            _unitOfWork.SaveChanges();
            return CreatedAtRoute("GetStudent",new Student());
        }
        [HttpGet("MyCourses")]
        public async Task<IActionResult> GetMyCourses()
        {
            if (!User.Identity.IsAuthenticated)
                return Unauthorized();

            var courses = await _unitOfWork.Course.GetAllAsync();

            // Mapping courses upfront
            var allCoursesToReturn = courses.Select(course => _mapper.Map<CourseForBrowisngDto>(course)).ToList();

            // Error handling for parsing StudentId and fetching student
            if (!int.TryParse(User.Claims.FirstOrDefault(c => c.Type == "StudentId")?.Value, out var studentId))
            {
                return BadRequest("Invalid or missing StudentId claim.");
            }

            var student = await _unitOfWork.Student.FindAsync(s => s.StudentId == studentId);
            if (student == null)
            {
                return NotFound("Student not found.");
            }

            // Fetching all course enrollments
            var enrolledCourseIds = _unitOfWork.CourseEnrollment
                .GetAll()
                .Where(ce => ce.StudentId == studentId)
                .Select(ce => ce.CourseId)
                .ToList();

            if (enrolledCourseIds == null || !enrolledCourseIds.Any())
                return NoContent();

            // Filter courses based on enrollment
            var myCoursesToReturn = allCoursesToReturn.Where(c => enrolledCourseIds.Contains(c.CourseId)).ToList();

            return Ok(myCoursesToReturn);
        }

    }
}

