using AutoMapper;
using GraduationProjectAlpha.Dtos.Student;
using GraduationProjectAlpha.Dtos.User;
using GraduationProjectAlpha.Model;
using GraduationProjectAlpha.Services.IRepository;
using Microsoft.AspNetCore.Http;
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

        public AuthController(IUnitOfWork unitOfWork,IAuthRepository authRepository,IMapper mapper)
        {
            _authRepository = authRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(User user)
        {
            if (await _authRepository.Register(user))
            {
                StudentUserLinking(user);
                return Ok("User Added Successfully");
            }
            return BadRequest("SomethingWentWrong");
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
            return BadRequest("Some Thing Gone Mad, Go and Debug your code!");

        }
        private ActionResult<StudentCreateDto> StudentUserLinking(User user)
        {
            var student = new StudentCreateDto()
            {
                Email = user.Email,
                Password = user.Password,
                FName = user.FName,
                LName = user.LName,
                PhoneNumber = user.PhoneNumber,
                Sex = user.Sex,
                DateOfBirth = user.DateOfBirth,
                Level = user.Level
            };

            var studentToBeAdd = _mapper.Map<Student>(student);

            _unitOfWork.Students.AddAsync(studentToBeAdd);

            _unitOfWork.Save();

            var studentReadDto = _mapper.Map<StudentReadDto>(studentToBeAdd);

            return Ok(studentReadDto);

        }
    }
}
