using AutoMapper;
using GraduationProjectAlpha.Dtos.Course;
using GraduationProjectAlpha.Model;

namespace GraduationProjectAlpha.Profiles
{
    public class SectionProfile : Profile
    {
        public SectionProfile()
        {
            CreateMap<Section, SectionDto>()
                .ForMember(dest => dest.SectionName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ModuleDtos, opt => opt.MapFrom(src => src.Modules));
        }
    }
}
