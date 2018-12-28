using System;
using AutoMapper;
using Cqrs.Service.Command;
using Cqrs.Service.CommandHandlers;
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
    public class AddEmployeeUnitTest : BaseTest<AddEmployeeCommandHandler>
    {
        private Mock<IBaseRepository<Employee>> _mockRepository;
        private Mock<IMapper> _mockMapper;

        [TestMethod]
        public void AddEmployee_ThrowsException_WhenParameterIsNull()
        {
            Action check = () => { CreateItemToTest().Execute(null); };
            check.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void AddEmployee_ShouldAddEmployee()
        {
            CreateItemToTest().Execute(new AddEmployeeCommand(new EmployeeDto()));

            _mockMapper.Verify(mock => mock.Map(It.IsAny<EmployeeDto>(), It.IsAny<Employee>()), Times.Exactly(1));
            _mockRepository.Verify(mock => mock.Add(It.IsAny<Employee>()), Times.Exactly(1));
            _mockRepository.Verify(mock => mock.Save(), Times.Exactly(1));
        }

        protected override void SetupMockingForTests()
        {
            _mockRepository = new Mock<IBaseRepository<Employee>>();
            _mockMapper = new Mock<IMapper>();
        }

        protected override AddEmployeeCommandHandler CreateItemToTest()
        {
            return new AddEmployeeCommandHandler(_mockRepository.Object, _mockMapper.Object);
        }
    }
}
