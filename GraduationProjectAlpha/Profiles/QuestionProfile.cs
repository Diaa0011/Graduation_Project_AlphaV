using AutoMapper;
using GraduationProjectAlpha.Dtos.Course;
using GraduationProjectAlpha.Model;

namespace GraduationProjectAlpha.Profiles
{
    public class QuestionProfile : Profile
    {
        public QuestionProfile()
        { 
            CreateMap<Question, QuestionDto>();
            CreateMap<Question, QuestionWithStudentAnswerDto>();

        }
    }
}
