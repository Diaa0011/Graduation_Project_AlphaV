using AutoMapper;
using GraduationProjectAlpha.Dtos.Student;
using GraduationProjectAlpha.Dtos.User;
using GraduationProjectAlpha.Model;
using GraduationProjectAlpha.Services.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Security.Claims;

namespace GraduationProjectAlpha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthController(IUnitOfWork unitOfWork,
            IAuthRepository authRepository,
            IMapper mapper,
            UserManager<IdentityUser> userManager)
        {
            _authRepository = authRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(UserDto user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("fix your data first!");
            }
            if (await _authRepository.Register(user))
            {
                StudentUserLinking(user);
                return Ok("User Added Successfully");
            }
            return BadRequest("Something Went Wrong");
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserDto user)
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
            return Unauthorized("Wrong email or password!");

        }
        private async Task<IActionResult> StudentUserLinking(UserDto user)
        {
            var student = new StudentCreateDto()
            {
                Email = user.Email,
                Password = user.Password,
                FName = user.FName,
                LName = user.LName,
                PhoneNumber = user.PhoneNumber,
                DateOfBirth = user.DateOfBirth,
                Level = user.Level,
            };

            var studentToBeAdd = _mapper.Map<Student>(student);

            await _unitOfWork.Student.AddAsync(studentToBeAdd);

            _unitOfWork.SaveChanges();

            //var studentReadDto = _mapper.Map<StudentReadDto>(studentToBeAdd);

            return Ok();

        }
    }
}
