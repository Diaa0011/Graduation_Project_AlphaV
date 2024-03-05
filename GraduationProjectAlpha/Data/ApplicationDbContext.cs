using GraduationProjectAlpha.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GraduationProjectAlpha.Model.Enums;

namespace GraduationProjectAlpha.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
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
                    Email = "AhmedMahmoud@Mail.com",
                    Password = "123456@Mail",
                    Sex = Sex.Male,
                    DateOfBirth = new DateTime(2001, 02, 14),
                    Level = Level.ThirdSecondary,

                }
                );

            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }

        }
    }
}
