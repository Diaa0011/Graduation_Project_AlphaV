using System;

public class CourseDto
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }
	public string ImageUrl { get; set; }
	public bool IsActive { get; set; }
	public DateTime? StartDate { get; set; }
	public DateTime? EndDate { get; set; }
	public string InstructorName { get; set; }
	//public List<string> Categories { get; set; }
	public bool IsEnrolled { get; set; }
	// ... other DTO properties as needed
}

//Filter Implementation:

//Create a separate FilterDto class with properties corresponding to your filter criteria (e.g., CategoryName, PriceRange, StartDateAfter).
//Pass the FilterDto instance to your service method or data access layer, along with other parameters.
//Implement filtering logic in your service or repository based on the provided criteria.
