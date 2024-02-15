using System;

public class CourseProgressSummaryDto
{
	public int TotalLessons { get; set; }
	public int CompletedLessons { get; set; }
	public int TotalQuizzes { get; set; }
	public int CompletedQuizzes { get; set; }
}