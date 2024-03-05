using GraduationProjectAlpha.Entities;
using GraduationProjectAlpha.Services.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProjectAlpha.Controllers
{
	[ApiController]
	[Route("students")]
	public class StudentController:ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;
		public StudentController(IUnitOfWork unitOfWork)
		{
				_unitOfWork = unitOfWork;
		}
		[HttpGet]
		public async Task<IActionResult> GetAllStudents()
		{
			var students = await _unitOfWork.Students.GetAllAsync();
			return Ok(students);
		}
		[HttpGet("id")]
		public async Task<IActionResult> GetStudent(int id)
		{
			var student = await _unitOfWork.Students.GetByIdAsync(id);
			return Ok(student);
		}

		////[HttpPost("AddStudent")]
		////public IActionResult AddStudent(Student student)
		////{
		////	if (!ModelState.IsValid) // Basic validation check
		////	{
		////		return BadRequest(ModelState); // Return bad request with validation errors
		////	}

		////	// Implement data access logic to create the student in your database
		////	// ... (e.g., using Entity Framework)

		////	return CreatedAtRoute("GetStudent", new { id = student.Id }, student); // Created with location
		////}


	}
}

