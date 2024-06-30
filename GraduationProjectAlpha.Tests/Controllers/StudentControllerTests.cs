using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using GraduationProjectAlpha.Controllers;
using GraduationProjectAlpha.Dtos.Student;
using GraduationProjectAlpha.Model;
using GraduationProjectAlpha.Services.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GraduationProjectAlpha.Tests.Controllers
{
    public class StudentControllerTests
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public StudentControllerTests()
        {
            _unitOfWork = A.Fake<IUnitOfWork>();
            _mapper = A.Fake<IMapper>();
        }
        [Fact]
        public async void StduentController_GetAllStudents_RetrunOk()
        {
            //Arranage
            var students = A.Fake<IEnumerable<Student>>();
            var studentList = A.Fake<IEnumerable<StudentReadDto>>();
            A.CallTo(() => _mapper.Map<IEnumerable<StudentReadDto>>(students)).Returns(studentList);
            //A.CallTo(() => _unitOfWork.Student.GetAll()).Returns(students);
            //A.CallTo(() => _mapper.Map<StudentReadDto>(students)).Returns(students);
            var controller = new StudentController(_unitOfWork, _mapper);
            //Act
            var result = await controller.GetAllStudents();
            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }
    }
}
