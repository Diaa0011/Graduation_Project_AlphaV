using AutoMapper;
using GraduationProjectAlpha.Dtos.Course;
using GraduationProjectAlpha.Model;

namespace GraduationProjectAlpha.Profiles
{
    public class QuizProfile : Profile
    {
        public QuizProfile()
        {
            CreateMap<Quiz, QuizDto>();
        }
    }
}
