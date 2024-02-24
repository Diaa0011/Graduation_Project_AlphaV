using GraduationProjectAlpha.Model;
using GraduationProjectAlpha.Services.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace GraduationProjectAlpha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(User user)
        {
            if (await _authRepository.Register(user))
            {
                return Ok("User Added Successfully");
            }
            return BadRequest("SomethingWentWrong");
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(User user)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            if(await _authRepository.Login(user))
            {
                var tokenString = _authRepository.GenerateToken(user);
                
                return Ok(tokenString);
            }
            return BadRequest("Some Thing Gone Mad, Go and Debug your code!");

        }
    }
}
