using System;

public class ModuleDto
{
	public string Name { get; set; }
	public IEnumerable<LessonDto> Lessons { get; set; }
	public IEnumerable<QuizDto> Quizzes { get; set; }
}
