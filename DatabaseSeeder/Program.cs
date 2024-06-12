using GraduationProject.DatabaseSeeder.Context;
using GraduationProject.DatabaseSeeder;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GraduationProjectAlpha.DbContexts;

var services = new ServiceCollection();

services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer("Server=. ;Database=ThirdDatabase;Trusted_Connection=True ;TrustServerCertificate=True"));

var serviceProvider = services.BuildServiceProvider();
using (var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>())
{
    var dataGenerator = new DataGenerator(dbContext);
    dataGenerator.Generate();

    //var courses = dbContext.Courses.Include(c => c.Sections).ThenInclude(s => s.Modules).ThenInclude(m => m.Lessons).ToList();
    //var json = JsonConvert.SerializeObject(courses, Formatting.Indented, new JsonSerializerSettings
    //{
    //    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
    //});

    ////Console.WriteLine(json);
    //var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
    //var filePath = Path.Combine(desktopPath, "THECOURSES.json");

    //// Write the JSON to the file
    //File.WriteAllText(filePath, json);
}

Console.WriteLine("Data inserted successfully into the in-memory database!");
