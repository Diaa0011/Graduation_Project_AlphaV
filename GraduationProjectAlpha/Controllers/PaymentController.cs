using GraduationProjectAlpha.Services.Repository;
using GraduationProjectAlpha.Services.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GraduationProjectAlpha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public PaymentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> SubmitPayment()
        {
            if (!User.Identity.IsAuthenticated) return Unauthorized();
            var studentId = int.Parse(User.FindFirstValue("StudentId"));
            _unitOfWork.Student
                .GetById(studentId)
                .HasPaid = true;
            _unitOfWork.SaveChanges();
            return Ok();
                
        }
    }
}
