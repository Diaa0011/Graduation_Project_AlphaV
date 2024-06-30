using AutoMapper;
using GraduationProjectAlpha.Dtos.Course;
using GraduationProjectAlpha.Model;

namespace GraduationProjectAlpha.Profiles
{
    public class ModuleProfile : Profile
    {
        public ModuleProfile()
        {
            CreateMap<Module, ModuleDto>()
                .ForMember(dest => dest.ModuleName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.LessonDtos , opt => opt.MapFrom(src => src.Lessons))
                .ForMember(dest => dest.QuizDtos , opt => opt.MapFrom(src => src.Quizzes));
        }
    }
}
