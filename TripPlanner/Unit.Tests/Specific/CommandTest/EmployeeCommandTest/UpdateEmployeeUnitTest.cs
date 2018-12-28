using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Cqrs.Service.Command;
using Cqrs.Service.CommandHandlers;
using Cqrs.Service.Exceptions;
using DomainModels;
using Entity.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Repositories.Contracts;
using Unit.Tests.Generic;

namespace Unit.Tests.Specific.CommandTest.EmployeeCommandTest
{
    [TestClass]
    public class UpdateEmployeeUnitTest : BaseTest<UpdateEmployeeCommandHandler>
    {
        private Mock<IBaseRepository<Employee>> _mockRepository;
        private Mock<IMapper> _mockMapper;
        private Employee employee;
        private EmployeeDto employeeDto;

        [TestMethod]
        public void UpdateEmployee_ThrowsException_WhenParameterIsNull()
        {
            Action check = () => { CreateItemToTest().Execute(null); };
            check.Should().Throw<ArgumentNullException>();
        }


        [TestMethod]
        public void UpdateEmployee_ShouldThrowError_WhenEmployeeNotFound()
        {
            Action check = () => { CreateItemToTest().Execute(new UpdateEmployeeCommand(new EmployeeDto())); };
            check.Should().Throw<GeneralBusinessException>().WithMessage("Employee not found");
        }

        [TestMethod]
        public void UpdateEmployee_ShouldUpdateEmployee()
        {
            MockEmployee(employee);
            CreateItemToTest().Execute(new UpdateEmployeeCommand(employeeDto));

            _mockMapper.Verify(mock => mock.Map(It.IsAny<EmployeeDto>(), It.IsAny<Employee>()), Times.Exactly(1));
            _mockRepository.Verify(mock => mock.Save(), Times.Exactly(1));
        }

        private void MockEmployee(Employee employee)
        {
            _mockRepository.Setup(x => x.Get(employee.Id))
                .Returns(employee);
        }

        protected override void SetupMockingForTests()
        {
            _mockRepository = new Mock<IBaseRepository<Employee>>();
            _mockMapper = new Mock<IMapper>();
            employee = new Employee
            {
                Id = Guid.NewGuid()
            };

            employeeDto = new EmployeeDto
            {
                Id = employee.Id
            };
        }



        protected override UpdateEmployeeCommandHandler CreateItemToTest()
        {
            return new UpdateEmployeeCommandHandler(_mockMapper.Object, _mockRepository.Object);
        }
    }
}
