using AutoMapper;
using GraduationProjectAlpha.Dtos.Course;
using GraduationProjectAlpha.Services.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProjectAlpha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CourseController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> BrowseCourses()
        {
            var courses = await _unitOfWork.Course.GetAllAsync();

            // Mapping courses upfront
            var allCoursesToReturn = courses.Select(course => _mapper.Map<CourseForBrowisngDto>(course)).ToList();

            if (!User.Identity.IsAuthenticated) return Ok(allCoursesToReturn);

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

            var enrolledCourseIds = _unitOfWork.CourseEnrollment
                .GetAll()
                .Where(ce => ce.Student.StudentId == studentId)
                .Select(ce => ce.Course.CourseId)
                .ToList();

            // Filter courses based on enrollment
            var myCoursesToReturn = allCoursesToReturn.Where(c => enrolledCourseIds.Contains(c.CourseId)).ToList();

            // Remove enrolled courses from all courses
            var remainingCourses = allCoursesToReturn.ExceptBy(myCoursesToReturn.Select(c => c.CourseId), c => c.CourseId).ToList();

            return Ok(new { myCoursesToReturn, remainingCourses });
        }

    }
}
