using AutoMapper;
using GraduationProjectAlpha.Dtos.Student;
using GraduationProjectAlpha.Dtos.User;
using GraduationProjectAlpha.Model;
using GraduationProjectAlpha.Models.Enums;
using GraduationProjectAlpha.Services.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GraduationProjectAlpha.Services
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        private readonly IConfiguration _config;

       
        public AuthRepository(UserManager<IdentityUser> userManager,IConfiguration configuration,
            SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _config = configuration;
        }
        public async Task<bool> Register(User user)
        {
            var identityUser = new IdentityUser
            {
                UserName = user.FName + "" + user.LName,
                Email = user.Email,
            };
            var result = await _userManager.CreateAsync(identityUser, user.Password);
            
            return result.Succeeded;
        }

        public async Task<bool> Login(LoginUserDto user)
        {
            //var identityUser = await _userManager.FindByEmailAsync(user.Email);
            var identityUser = await _signInManager.PasswordSignInAsync(user.Email, user.Password, false, lockoutOnFailure: false);
            if (identityUser is null)
            {
                return false;
            }
            return true;
        }

        //Generate Token after Login
        public string GenerateToken(LoginUserDto user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Role,"Admin"),
                new Claim(ClaimTypes.Role,"Student")
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("Jwt:Key").Value));

            var signingCred = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha512Signature);

            var securityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                issuer: _config.GetSection("Jwt:Issuer").Value,
                audience: _config.GetSection("Jwt:Audience").Value,
                signingCredentials: signingCred
                );
            string tokenString = new JwtSecurityTokenHandler().WriteToken(securityToken);

            return tokenString; 
        }

        
    }
}
