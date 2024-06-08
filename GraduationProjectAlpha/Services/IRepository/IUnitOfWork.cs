namespace GraduationProjectAlpha.Services.IRepository
{
    public interface IUnitOfWork
    {
        IStudentRepository Student { get; }
        ICourseRepository Course { get; }
        ICourseEnrollmentRepository CourseEnrollment { get; }
        ILessonRepository Lesson { get; set; }
        IQuizRepository Quiz { get; set; }

        void SaveAsync();
    }
}
