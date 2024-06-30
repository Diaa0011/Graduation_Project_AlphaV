using AutoMapper;
using GraduationProjectAlpha.Dtos.Course;
using GraduationProjectAlpha.Model;

namespace GraduationProjectAlpha.Profiles
{
    public class LessonProfile : Profile
    {
        public LessonProfile()
        {
            CreateMap<Lesson, LessonForCourseTreeDto>();
            CreateMap<Lesson, LessonDto>();
        }
    }
}
