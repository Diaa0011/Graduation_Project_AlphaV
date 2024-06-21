using AutoMapper;
using GraduationProjectAlpha.Dtos.Course;
using GraduationProjectAlpha.Model;
using GraduationProjectAlpha.Models.Enums;
using GraduationProjectAlpha.Services.Repository.IRepository;
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
        public async Task<IActionResult> BrowseCourses([FromQuery] string? searchQuery)
        {
            var courses = await _unitOfWork.Course.GetAllAsync();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                courses = courses.Where(c => 
                c.Name.Contains(searchQuery, StringComparison.OrdinalIgnoreCase) ||
                c.Description.Contains(searchQuery, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
            // Mapping courses upfront
            var allCoursesToReturn = courses.Select(course => _mapper.Map<CourseForBrowisngDto>(course)).ToList();

            if (!User.Identity.IsAuthenticated) return new JsonResult(allCoursesToReturn) { ContentType = "application/json" };

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

            return new JsonResult(new { myCoursesToReturn, remainingCourses }) { ContentType = "application/json" };
        }

        [HttpGet("{courseId}/details")]
        public async Task<IActionResult> GetCourseDetails(int courseId)
        {
            var course = await _unitOfWork.Course.GetCourseDetailsAsync(courseId);
            if (course == null) return NotFound("There's no such course");
            var courseDetails = _mapper.Map<CourseDetailsDto>(course);
            var courseAvgRating = await _unitOfWork.CourseEnrollment.CalculateCourseAvgRatingAsync(courseId);
            courseDetails.RatingAverage = courseAvgRating;

            return Ok(courseDetails);
        }

        [HttpPost("{courseId}/enroll")]
        public async Task<IActionResult> EnrollInCourse(int courseId)
        {

            if (!User.Identity.IsAuthenticated) return Unauthorized();

            var studentId = int.Parse(User.FindFirstValue("StudentId"));

            var course = _unitOfWork.Course.GetById(courseId);
            if(course == null)
            {
                return NotFound("The course doesn't exist");
            }
            await _unitOfWork.CourseEnrollment.EnrollAsync(studentId, courseId);

            return Ok("The student has been enrolled to course sucessfuly");
        }

        [HttpGet("{courseId}/content")]
        public async Task<IActionResult> GetCourseContent(int courseId)
        {
            if (!User.Identity.IsAuthenticated) return Unauthorized();

            var course = await _unitOfWork.Course.GetCourseDetailsAsync(courseId);

            if (course == null) return NotFound("The course you are asking for may be not existing or have been removed");

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
            if (!User.Identity.IsAuthenticated) return Unauthorized();

            var course = await _unitOfWork.Course.GetCourseDetailsAsync(courseId);
            if (course == null) return NotFound("The course you are asking for may not be existing or has been removed");

            var lesson = await _unitOfWork.Lesson.GetLessonFromCourseAsync(lessonId, courseId);
            if (lesson == null) return NotFound("The course you are asking for may not be existing or has been removed or the lesson doesn't belong to the course you're browsing for.");

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
            if (!User.Identity.IsAuthenticated) return Unauthorized();

            var course = await _unitOfWork.Course.GetByIdAsync(courseId);
            if (course == null) return NotFound("The course you are asking for may not be existing or has been removed");
            var quiz = await _unitOfWork.Quiz.GetQuizFromCourse(quizId, courseId);
            if (quiz == null) return NotFound("The quiz you're asking for may not be existing or has been removed or the quiz belong to other course");
            var quizDto = _mapper.Map<QuizDto>(quiz);
            return Ok(quizDto);
        }

        [HttpPost("{courseId}/content/quiz/{quizId}/submit")]
        public async Task<IActionResult> SubmitQuiz(int courseId,int quizId,[FromBody] QuizSubmissionDto quizSubmissionDto)
        {
            if (!User.Identity.IsAuthenticated) return Unauthorized();

            var studentId = int.Parse(User.FindFirstValue("StudentId"));

            // Validate course existence
            var course = await _unitOfWork.Course.GetByIdAsync(courseId);
            if (course == null)
            {
                return NotFound("The course you're submitting to may not be existing");
            }

            // Validate quiz existence
            var quiz = await _unitOfWork.Quiz.GetQuizFromCourse(quizId, courseId);
            if (quiz == null)
            {
                return NotFound("The quiz you're submitting to may not be existing or does not belong to the specified course");
            }
            var quizReport = _mapper.Map<QuizReportDto>(quiz);
            // Initialize total grade
            int totalGrade = 0;

            // Process each question answer
            foreach (var questionAnswer in quizSubmissionDto.QuestionAnswers)
            {
                var question = await _unitOfWork.Question.GetByIdAsync(questionAnswer.QuestionId);

                if (question == null || question.QuizId != quiz.QuizId)
                {
                    return BadRequest($"Invalid question ID: {questionAnswer.QuestionId}");
                }

                var studentChoiceStatus = StudentChoiceStatus.Missing;
                if (questionAnswer.ChoiceId.HasValue)
                {
                    studentChoiceStatus = questionAnswer.ChoiceId == question.RightChoiceId
                        ? StudentChoiceStatus.Correct
                        : StudentChoiceStatus.Wrong;
                }

                var studentQuestionInteraction = new StudentQuestionInteraction
                {
                    StudentId = studentId,
                    QuestionId = question.QuestionId,
                    StudentChoiceId = questionAnswer.ChoiceId,
                    StudentChoiceStatus = studentChoiceStatus
                };


                // Add interaction to the database
                await _unitOfWork.StudentQuestionInteraction.AddAsync(studentQuestionInteraction);

                // Increment total grade if the answer is correct
                if (studentQuestionInteraction.StudentChoiceStatus == StudentChoiceStatus.Correct)
                {
                    totalGrade += question.Grade;
                }
                var questionInReport = quizReport.Questions.FirstOrDefault(q => q.QuestionId == questionAnswer.QuestionId);
                questionInReport.ChoiceStatus = studentChoiceStatus;
                questionInReport.StudentChoiceId = questionAnswer.ChoiceId;
                    
            }

            // Record student's interaction with the quiz
            var studentQuizInteraction = new StudentQuizInteraction
            {
                StudentId = studentId,
                QuizId = quiz.QuizId,
                OverallGrade = totalGrade
            };

            await _unitOfWork.StudentQuizInteraction.AddAsync(studentQuizInteraction);

            // Save all changes to the database
            _unitOfWork.SaveChanges();

            return Ok(new { totalGrade, quizReport });
        }

    }
}
