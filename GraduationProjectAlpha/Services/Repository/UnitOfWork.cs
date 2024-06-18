using GraduationProjectAlpha.DbContexts;
using GraduationProjectAlpha.Services.Repository.IRepository;

namespace GraduationProjectAlpha.Services.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IStudentRepository Student { get; private set; }
        public ICourseRepository Course { get; private set; }
        public ICourseEnrollmentRepository CourseEnrollment { get; set; }
        public ILessonRepository Lesson { get; set; }
        public IQuizRepository Quiz { get; set; }
        public IQuestionRepository Question { get; set; }
        public IStudentQuestionInteractionRepository StudentQuestionInteraction { get; set; }
        public IStudentQuizInteractionRepository StudentQuizInteraction { get; set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _context = db;
            Student = new StudentRepository(_context);
            Course = new CourseRepository(_context);
            CourseEnrollment = new CourseEnrollmentRepository(_context);
            Lesson = new LessonRepository(_context);
            Quiz = new QuizRepository(_context);
            Question = new QuestionRepository(_context);
            StudentQuestionInteraction = new StudentQuestionInteractionRepository(_context);
            StudentQuizInteraction = new StudentQuizInteractionRepository(_context);
        }
        public void SaveChanges()
        {
           _context.SaveChanges();
        }
    }
}
