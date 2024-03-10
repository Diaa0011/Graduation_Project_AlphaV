using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using GraduationProjectAlpha.Controllers;
using GraduationProjectAlpha.Dtos.User;
using GraduationProjectAlpha.Services;
using GraduationProjectAlpha.Services.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Printing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using System.Net;
using FakeItEasy;
using System.ComponentModel.DataAnnotations;

namespace GraduationProjectAlpha.Tests.Controllers
{
    public class AuthControllerTests
    {
        private readonly AuthController _authController;
        private readonly IAuthRepository _authRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthControllerTests()
        {
            // Arrange: Set up your dependencies (mocks or real services)
            _authRepository = A.Fake<IAuthRepository>();
            _mapper = A.Fake<IMapper>();
            _userManager = A.Fake<UserManager<IdentityUser>>();
            _unitOfWork = A.Fake<IUnitOfWork>();
            _authController = new AuthController(_unitOfWork,_authRepository, _mapper, _userManager);
        }

        [Fact]
        public async Task RegisterUser_ValidInput_ReturnsOk()
        {
            // Arrange
            var user1success = new UserDto
            {
                Email = "MadMazen12@mail.com",
                FName = "Mad",
                LName = "Mazen",
                Password = "159@Mail",
                PhoneNumber = "0123456789",
                DateOfBirth = DateTime.Now,
                Level = (Models.Enums.Level)12
            };
            var user2success = new UserDto
            {
                Email = "MahmoudAhmed@gmail.com",
                FName = "Mahmoud",
                LName = "Ahmed",
                Password = "123456789@Gmail",
                PhoneNumber = "0123456789",
                DateOfBirth = DateTime.Now,
                Level = (Models.Enums.Level)12
            };
            //invalid mail data
            var user1fail = new UserDto
            {
                Email = "MadMazen12",
                FName = "Mad",
                LName = "Mazen",
                Password = "159",
                PhoneNumber = "123456789",
                DateOfBirth = DateTime.Now,
                Level = (Models.Enums.Level)12
            }; 
            //invalid mail , password 
            var user2fail = new UserDto
            {
                Email = "MadMazen12",
                FName = "Mad",
                LName = "Mazen",
                Password = "159",
                PhoneNumber = "123456789",
                DateOfBirth = DateTime.Now,
                Level = (Models.Enums.Level)12
            };
            

            // Act
            var result1 = await _authController.RegisterUser(user1success);
            var result2 = await _authController.RegisterUser(user2success);
            var validation1 = ValidateModel(user1success);
            var validation2 = ValidateModel(user2success);
            var validation3 = ValidateModel(user1fail);
            // Assert
            Assert.IsType<OkObjectResult>(result1);
            Assert.IsType<OkObjectResult>(result2);
            Assert.Empty(validation1);
            Assert.Empty(validation2);
            //Assert.Empty(validation3);
        }
        [Fact]
        public async Task Login_ValidData_ReturnsTokenString()
        {
            // Arrange
            var validLoginUserDto = new LoginUserDto()
            {
                Email = "MadMazen2@Mail.com",
                Password = "159@Mail"
            }
                ;
            // Simulate successful login
            A.CallTo(() => _authRepository.Login(validLoginUserDto)).Returns(true);

            // Act
            var result = await _authController.Login(validLoginUserDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value); // Ensure token string is returned
        }

        //Helper function to check validations
        private static IList<ValidationResult> ValidateModel(UserDto user)
        {
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(user, serviceProvider: null, items: null);
            Validator.TryValidateObject(user, context, validationResults, validateAllProperties: true);
            return validationResults;
        }

    }
}
