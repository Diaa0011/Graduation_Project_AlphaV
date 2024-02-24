using GraduationProjectAlpha.Model;
using GraduationProjectAlpha.Services.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GraduationProjectAlpha.Services
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _config;

        public AuthRepository(UserManager<IdentityUser> userManager,IConfiguration configuration)
        {
            _userManager = userManager;
            _config = configuration;
        }
        public async Task<bool> Register(User user)
        {
            var identityUser = new IdentityUser
            {
                UserName = user.UserName,
                Email = user.Email,
            };
            var result = await _userManager.CreateAsync(identityUser, user.Password);
            
            return result.Succeeded;
        }

        public async Task<bool> Login(User user)
        {
            var identityUser = await _userManager.FindByEmailAsync(user.Email);
            if (identityUser is null)
            {
                return false;
            }
            return await _userManager.CheckPasswordAsync(identityUser, user.Password);
        }

        //Generate Token after Login
        public string GenerateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Role,"Admin"),
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
