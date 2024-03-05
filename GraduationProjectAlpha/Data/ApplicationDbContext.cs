using GraduationProjectAlpha.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraduationProjectAlpha.DbContexts
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {        
            
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    FName = "Ahmed",
                    LName = "Mahmoud",
                    PhoneNumber = "1234567890",
                    Email="AhmedMahmoud@Mail.com",
                    Sex = Models.Enums.Sex.Male,
                    DateOfBirth = new DateTime(2001, 02, 14),
                    Level = Models.Enums.Level.ThirdSecondary,

                }
                );
            
            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }

        }
    }
}
