using AutoMapper;
using GraduationProjectAlpha.Entities;
using GraduationProjectAlpha.Models;

namespace GraduationProjectAlpha.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserRegisterationDto, User>();
        }
    }
}
