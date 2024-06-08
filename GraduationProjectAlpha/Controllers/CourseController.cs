using AutoMapper;
using GraduationProjectAlpha.Dtos.Course;
using GraduationProjectAlpha.Services.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Security.Claims;

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

        [HttpGet("{courseId}/details")]
        public async Task<IActionResult> GetCourseDetails(int courseId)
        {
            var course = await _unitOfWork.Course.GetCourseDetailsAsync(courseId);
            if (course == null) return BadRequest("There's no such course");
            var courseDetails = _mapper.Map<CourseDetailsDto>(course);
            var courseAvgRating = _unitOfWork.CourseEnrollment.CalculateCourseAvgRating(courseId);
            courseDetails.RatingAverage = courseAvgRating;

            return Ok(courseDetails);
        }

        [HttpPost("{courseId}/enroll")]
        public async Task<IActionResult> EnrollInCourse(int courseId)
        {

            if (!User.Identity.IsAuthenticated) return Unauthorized();

            var studentId = int.Parse(User.FindFirstValue("StudentId"));
            await _unitOfWork.CourseEnrollment.EnrollAsync(studentId, courseId);

            return Ok();
        }

        [HttpGet("{courseId}/content")]
        public async Task<IActionResult> GetCourseContent(int courseId)
        {
            var course = await _unitOfWork.Course.GetCourseDetailsAsync(courseId);

            if (course == null) return BadRequest("The course you are asking for may be not existing or have been removed");

            var sections = course.Sections;

            var sectionsDto = new List<SectionDto>();

            foreach (var section in sections)
            {
                var sectionDto = _mapper.Map<SectionDto>(section);
                sectionsDto.Add(sectionDto);
            }

            return Ok(sectionsDto);
        }

        [HttpGet("{courseId}/content/lesson/{lessonId}")]
        public async Task<IActionResult> GetLessonContent(int courseId, int lessonId)
        {
            var course = await _unitOfWork.Course.GetCourseDetailsAsync(courseId);
            if (course == null) return BadRequest("The course you are asking for may not be existing or has been removed");

            var lesson = await _unitOfWork.Lesson.GetLessonFromCourseAsync(lessonId, courseId);
            if (lesson == null) return BadRequest("The course you are asking for may not be existing or has been removed or the lesson doesn't belong to the course you're browsing for.");

            var sections = course.Sections;

            var sectionsDto = new List<SectionDto>();

            foreach (var section in sections)
            {
                var sectionDto = _mapper.Map<SectionDto>(section);
                sectionsDto.Add(sectionDto);
            }

            var lessonDto = _mapper.Map<LessonDto>(lesson);

            return Ok(new { lessonDto, sectionsDto });
        }

        [HttpGet("{courseId}/content/quiz/{quizId}")]
        public async Task<IActionResult> GetQuizContent(int courseId, int quizId)
        {
            var course = await _unitOfWork.Course.GetByIdAsync(courseId);
            if (course == null) return BadRequest("The course you are asking for may not be existing or has been removed");
            var quiz = await _unitOfWork.Quiz.GetQuizFromCourse(quizId, courseId);
            if (quiz == null) return BadRequest("The quiz you're asking for may not be existing or has been removed or the quiz belong to other course");
            var quizDto = _mapper.Map<QuizDto>(quiz);
            return Ok(quizDto);
        }
    }
}
