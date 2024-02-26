using AutoMapper;
using GraduationProjectAlpha.Entities;
using GraduationProjectAlpha.Models;

namespace GraduationProjectAlpha.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<UserRegisterationDto, Student>();
        }
    }
}
