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
            CreateMap<Course, CourseDetailsDto>()
                .ForMember(dest => dest.CourseName, option => option.MapFrom(src => src.Name))
                .ForMember(dest => dest.SectionDtos, opt => opt.MapFrom(src => src.Sections));
        }
    }
}
