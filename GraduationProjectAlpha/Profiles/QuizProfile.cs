using AutoMapper;
using GraduationProjectAlpha.Dtos.Course;
using GraduationProjectAlpha.Model;

namespace GraduationProjectAlpha.Profiles
{
    public class QuizProfile : Profile
    {
        public QuizProfile()
        {
            CreateMap<Quiz, QuizForCourseTreeDto>();
            CreateMap<Quiz, QuizDto>();
            CreateMap<Quiz, QuizReportDto>();
        }
    }
}
