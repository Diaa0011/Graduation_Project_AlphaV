using AutoMapper;
using GraduationProjectAlpha.Entities;
using GraduationProjectAlpha.Models;
using GraduationProjectAlpha.Services;
using GraduationProjectAlpha.Services.Repository.IRepository;
using Microsoft.AspNetCore.Http;
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

        public AuthenticationController(IUnitOfWork unitOfWork, IPasswordHasher passwordHasher, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
        }
        [HttpPost("registeration")]
        public async Task<IActionResult> Register(UserRegisterationDto userDto)
        {
            var student = _mapper.Map<Student>(userDto);
            var user = _mapper.Map<User>(userDto);
            byte[] passwordHash, passwordSalt;
            _passwordHasher.CreatePasswordHash(userDto.Password, out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            return Ok(new
            {
                UserName = user.Username,
                PasswordHash = user.PasswordSalt,
                PasswordSalt = user.PasswordHash
            });
        }
    }
}
