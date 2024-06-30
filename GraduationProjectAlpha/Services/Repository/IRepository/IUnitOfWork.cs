namespace GraduationProjectAlpha.Services.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IStudentRepository Student { get; }
        ICourseRepository Course { get; }
        ICourseEnrollmentRepository CourseEnrollment { get; }
        ILessonRepository Lesson { get; set; }
        IQuizRepository Quiz { get; set; }
        IQuestionRepository Question { get; set; }
        IStudentQuestionInteractionRepository StudentQuestionInteraction { get; set; }
        IStudentQuizInteractionRepository StudentQuizInteraction { get; set; }

        void SaveChanges();
    }
}
