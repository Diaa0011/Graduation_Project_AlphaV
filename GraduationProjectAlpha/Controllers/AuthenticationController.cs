using AutoMapper;
using GraduationProjectAlpha.Entities;
using GraduationProjectAlpha.Models;
using GraduationProjectAlpha.Models.Enums;
using GraduationProjectAlpha.Services;
using GraduationProjectAlpha.Services.PasswordChecker;
using GraduationProjectAlpha.Services.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProjectAlpha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IMapper _mapper;
        private readonly JwtService _jwtService;
        private readonly PasswordCheckerService _passwordCheckerService;
        private readonly EmailCheckerService _emailCheckerService;

        public AuthenticationController(IUnitOfWork unitOfWork, IPasswordHasher passwordHasher, IMapper mapper, JwtService jwtService, PasswordCheckerService passwordCheckerService, EmailCheckerService emailCheckerService)
        {
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
            _jwtService = jwtService;
            _passwordCheckerService = passwordCheckerService;
            _emailCheckerService = emailCheckerService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterationDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("You have passed invaild registeration info, please enter a valid registeration info");
            }
            if (!userDto.FName.All(char.IsAsciiLetter))
            {
                return BadRequest("First Name has to be only letters");
            }

            if (!userDto.LName.All(char.IsAsciiLetter))
            {
                return BadRequest("Last Name has to be only letters");
            }

            if( !Enum.IsDefined(typeof(Sex), userDto.Sex) )
            {
                return BadRequest("Gaaaaaay");
            }

            if( !Enum.IsDefined(typeof(Level), userDto.Level) )
            {
                return BadRequest("Invaild Level");
            }

            if (!_emailCheckerService.IsEmailValid(userDto.Email))
            {
                return BadRequest("Invalid Email");
            }

            if (!_passwordCheckerService.IsPasswordValid(userDto.Password))
            {
                return BadRequest("Weak password, please enter stronger one");
            }
            
            if (userDto.Password != userDto.PasswordConfirmation)
            {
                return BadRequest("Password and password confirmation do not match.");
            }

            if(userDto.PhoneNumber.Length != 11)
            {
                return BadRequest("The Phone number is either longer or shorter than 11 digits");
            }

            if ( !userDto.PhoneNumber.All(char.IsAsciiDigit) )
            {
                return BadRequest("The Phone number has to be only digits");
            }

            if(!userDto.Username.All(char.IsAsciiLetterOrDigit))
            {
                return BadRequest("Invalid Username");
            }

            var isEmailExists = await _unitOfWork.User.FindUserByEmailAsync(userDto.Email) == null;

            if (!isEmailExists)
            {
                return BadRequest("Email does exist, please check that email or use other one");
            }

            var user = _mapper.Map<User>(userDto);
            var student = _mapper.Map<Student>(userDto);
    
            // Create password hash and salt
            byte[] passwordHash, passwordSalt;
            _passwordHasher.CreatePasswordHash(userDto.Password, out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            // Add user and student to database
            await _unitOfWork.User.AddUserAsync(user);
            await _unitOfWork.SaveAsync();

            // Retrieve user with generated UserId
            user = await _unitOfWork.User.FindUserByEmailAsync(user.Email);

            // Associate student with the user
            student.UserId = user.UserId;
            await _unitOfWork.Student.AddStudentAsync(student);
            await _unitOfWork.SaveAsync();

            var token = _jwtService.GenerateToken(user);
            Response.Headers.Add("Authorization", $"Bearer {token}");
            return NoContent();
        }
        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login(UserLoginDto userLoginDto)
        {
            if (!ModelState.IsValid)
            {
                BadRequest("Your Email or Password are invaild");
            }
            if(userLoginDto.Email == null || userLoginDto.Password == null)
            {
                return BadRequest("You haven't enter the email or password");
            }
            var user = await _unitOfWork.User.FindUserByEmailAsync(userLoginDto.Email);
            if(user == null)
            {
                return BadRequest("Invaild Email");
            }
            if (!_passwordHasher.VerifyPasswordHash(userLoginDto.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Wrong password");
            }

            var token = _jwtService.GenerateToken(user);
            Response.Headers.Add("Authorization", $"Bearer {token}");

            return Ok();
        }
    }
}
