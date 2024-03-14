using AutoMapper;
using GraduationProjectAlpha.Dtos.Course;
using GraduationProjectAlpha.Model;

namespace GraduationProjectAlpha.Profiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseForBrowisngDto>();
        }
    }
}
