using GraduationProjectAlpha.DbContexts;
using GraduationProjectAlpha.Services.IRepository;

namespace GraduationProjectAlpha.Repository
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationDbContext _db;
		public IStudentRepository Students { get; private set; }
		public UnitOfWork(ApplicationDbContext db)
		{
			_db = db;
			Students = new StudentRepository(_db);
		}
		public void Save()
		{
			_db.SaveChangesAsync();
		}
		public void Dispose()
		{
			_db.Dispose();
		}
	}
}
