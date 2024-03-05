# 2. Entity Configuration with Inheritance and Fluent API:

```cs
public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder.ToTable("Lessons");
        builder.HasKey(l => l.Id);

        builder.HasOne(l => l.Course)
            .WithMany(c => c.Lessons)
            .HasForeignKey(l => l.CourseId);

        builder.HasOne(l => l.Module)
            .WithMany(m => m.Lessons)
            .HasForeignKey(l => l.ModuleId);

        builder.HasIndex(l => l.IsDeleted); // Index for efficient filtering

        builder.Property(l => l.Name)
            .IsRequired()
            .HasMaxLength(255);

        // Add other property configurations as needed
    }
}

public class MyDbContext : DbContext
{
    public DbSet<Course> Courses { get; set; }
    public DbSet<Module> Modules { get; set; }
    public DbSet<Lesson> Lessons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new LessonConfiguration()); // Apply configuration

        // Apply configurations for other entities inheriting from BaseEntity
    }
}
```