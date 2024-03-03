using AutoMapper;
using GraduationProjectAlpha.Models;
using GraduationProjectAlpha.Services.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProjectAlpha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        public IUnitOfWork _unifOfWork { get; set; }
        public IMapper _mapper { get; set; }

        public CourseController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unifOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CourseDto>> GetCourse()
        {
            var courses = _unifOfWork.Course.GetAllCourses();
            var courseList = new List<CourseDto>();

            foreach (var course in courses)
            {
                var mappedCourse = _mapper.Map<CourseDto>(course);
                courseList.Add(mappedCourse);
            }

            return courseList;
        }
    }
}
