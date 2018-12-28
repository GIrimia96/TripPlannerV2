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
    public class AddTripUnitTest : BaseTest<AddTripCommandHandler>
    {
        private Mock<IBaseRepository<Trip>> _mockRepository;
        private Mock<IMapper> _mockMapper;

        [TestMethod]
        public void AddTrip_ThrowsException_WhenParameterIsNull()
        {
            Action check = () => { CreateItemToTest().Execute(null); };
            check.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void AddTrip_ShouldAddEmployee()
        {
            CreateItemToTest().Execute(new AddTripCommand(new TripDto()));

            _mockMapper.Verify(mock => mock.Map(It.IsAny<TripDto>(), It.IsAny<Trip>()), Times.Exactly(1));
            _mockRepository.Verify(mock => mock.Add(It.IsAny<Trip>()), Times.Exactly(1));
            _mockRepository.Verify(mock => mock.Save(), Times.Exactly(1));
        }

        protected override void SetupMockingForTests()
        {
            _mockRepository = new Mock<IBaseRepository<Trip>>();
            _mockMapper = new Mock<IMapper>();
        }

        protected override AddTripCommandHandler CreateItemToTest()
        {
            return new AddTripCommandHandler(_mockRepository.Object, _mockMapper.Object);
        }
    }
}
