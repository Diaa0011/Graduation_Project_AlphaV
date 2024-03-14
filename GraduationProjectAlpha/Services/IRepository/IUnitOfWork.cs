namespace GraduationProjectAlpha.Services.IRepository
{
    public interface IUnitOfWork
    {
        IStudentRepository Student { get; }
        ICourseRepository Course { get; }
        ICourseEnrollmentRepository CourseEnrollment { get; }

        void SaveAsync();
    }
}
