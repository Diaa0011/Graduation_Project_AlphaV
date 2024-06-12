using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using GraduationProject.DatabaseSeeder.Context;
using GraduationProjectAlpha.Model;
using static System.Net.WebRequestMethods;
using GraduationProjectAlpha.DbContexts;


namespace GraduationProject.DatabaseSeeder
{
    public class DataGenerator
    {
        private readonly ApplicationDbContext _context;

        public DataGenerator(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Generate()
        {
            var order = 0;
            var random = new Random();
            var courseFaker = new Faker<Course>()
                .RuleFor(c => c.Name, f => f.Lorem.Word())
                .RuleFor(c => c.Description, f => f.Lorem.Paragraph())
                .RuleFor(c => c.ImageUrl, f => f.Image.PicsumUrl())
                .RuleFor(c => c.TeacherName, f => f.Name.FullName())
                .RuleFor(c => c.IntroductionVideoUrl, f => "https://www.youtube.com/watch?v=ScMzIvxBSi4");

            var sectionFaker = new Faker<Section>()
                .RuleFor(s => s.Name, f => f.Lorem.Word())
                .RuleFor(s => s.Order, f => ++order);
            order = 0;
            var moduleFaker = new Faker<Module>()
                .RuleFor(m => m.Name, f => f.Lorem.Word())
                .RuleFor(m => m.Order, f => ++order);
            order = 0;
            var lessonFaker = new Faker<Lesson>()
                .RuleFor(l => l.Name, f => f.Commerce.ProductName())
                .RuleFor(l => l.VideoUrl, f => "https://www.youtube.com/watch?v=ScMzIvxBSi4")
                .RuleFor(l => l.PdfUrl, f => "https://s2.q4cdn.com/175719177/files/doc_presentations/Placeholder-PDF.pdf")
                .RuleFor(l => l.Description, f => f.Lorem.Sentence())
                .RuleFor(l => l.Order, f => ++order);

            var quizFaker = new Faker<Quiz>()
                .RuleFor(q => q.Title, f => f.Lorem.Word())
                .RuleFor(q => q.Order, f => ++order);
            order = 0;
            var questionFaker = new Faker<Question>()
                .RuleFor(q => q.QuestionText, f => f.Lorem.Paragraph())
                .RuleFor(q => q.ImageUrl, f => f.Random.Double(0, 1) > .7 ? f.Image.PicsumUrl() : null)
                .RuleFor(q => q.Grade, f => 1)
                .RuleFor(q => q.Order, f => ++order);
            order = 0;
            var choiceFaker = new Faker<Choice>()
                .RuleFor(c => c.ChoiceText, f => f.Lorem.Sentence())
                .RuleFor(c => c.Order, f => (order++ % 4) + 1);

            // Create and add 8 courses
            var courses = courseFaker.Generate(8);
            _context.Courses.AddRange(courses);
            _context.SaveChanges();

            foreach (var course in courses)
            {
                order = 0;
                var sections = sectionFaker.Generate(2);
                foreach (var section in sections)
                {
                    section.CourseId = course.CourseId;
                    _context.Sections.Add(section);
                    _context.SaveChanges();
                    order = 0;
                    var modules = moduleFaker.Generate(3);
                    foreach (var module in modules)
                    {
                        module.SectionId = section.SectionId;
                        _context.Modules.Add(module);
                        _context.SaveChanges();
                        order = 0;
                        var lessons = lessonFaker.Generate(5);
                        foreach (var lesson in lessons)
                        {
                            lesson.ModuleId = module.ModuleId;
                            _context.Lessons.Add(lesson);
                        }
                        var quizzes = quizFaker.Generate(3);
                        foreach (var quiz in quizzes)
                        {
                            quiz.ModuleId = module.ModuleId;
                            _context.Quizzes.Add(quiz);
                            _context.SaveChanges();
                            order = 0;
                            var questions = questionFaker.Generate(10);
                            foreach (var question in questions)
                            {
                                question.QuizId = quiz.QuizId;
                                _context.Questions.Add(question);
                                _context.SaveChanges();
                                order = 0;
                                var choices = choiceFaker.Generate(4);
                                foreach (var choice in choices)
                                {
                                    choice.QuestionId = question.QuestionId;
                                    _context.Choices.Add(choice);
                                    _context.SaveChanges();
                                }
                                question.RightChoiceId = choices[random.Next(4)].ChoiceId;
                                _context.SaveChanges();
                            }
                        }
                    }
                }
            }

            _context.SaveChanges();
        }
    }

}
