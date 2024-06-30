using GraduationProjectAlpha.Dtos.Student;
using GraduationProjectAlpha.Model;
using AutoMapper;
namespace GraduationProjectAlpha.Profiles
{
    public class StudentProfile:Profile
    {
        //Source -> Target
        public StudentProfile()
        {
            // Retrieve Students
            CreateMap<Student, StudentReadDto>();
            // Create Student
            CreateMap<StudentCreateDto, Student>();
            // Deletion
            
            // Editing

        }
    }
}
