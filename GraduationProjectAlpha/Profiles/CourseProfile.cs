using AutoMapper;
using GraduationProjectAlpha.Entities;
using GraduationProjectAlpha.Models;

namespace GraduationProjectAlpha.Profiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseDto>();
        }
    }
}
