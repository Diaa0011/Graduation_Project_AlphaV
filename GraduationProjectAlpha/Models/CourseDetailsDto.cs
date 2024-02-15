using System;

public class CourseDetailsDto
{
	public int Id { get; set; }
	public string Name { get; set; }
	public decimal Rating { get; set; } // 0.0 to 5.0 scale
	public int ReviewCount { get; set; } // Number of reviews
	public string TeacherName { get; set; }
	public string Description { get; set; }
	public string ImageUrl { get; set; } // URL of the course image
	public bool IsEnrolled { get; set; } // Flag indicating user's enrollment status
	public string EnrollNowUrl { get; set; } // URL for enrollment action

	// Nested object for lesson and quiz summary
	public CourseProgressSummaryDto ProgressSummary { get; set; }

	// Nested object for table of contents
	public CourseOutlineDto Outline { get; set; }
}