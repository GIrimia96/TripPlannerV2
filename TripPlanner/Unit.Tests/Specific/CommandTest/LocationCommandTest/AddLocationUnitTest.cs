using System;
using System.Collections.Generic;
using System.Text;
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

namespace Unit.Tests.Specific.CommandTest.LocationCommandTest
{
    [TestClass]
    public class AddLocationUnitTest : BaseTest<AddLocationCommandHandler>
    {
        private Mock<IBaseRepository<Location>> _mockRepository;
        private Mock<IMapper> _mockMapper;

        [TestMethod]
        public void AddLocation_ShouldThrowException_WhenCommandIsNull()
        {
            Action check = () => { CreateItemToTest().Execute(null); };
            check.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void AddLocation_ShouldAddLocation()
        {
            CreateItemToTest().Execute(new AddLocationCommand(new LocationDto()));

            _mockMapper.Verify(mock => mock.Map(It.IsAny<LocationDto>(), It.IsAny<Location>()), Times.Exactly(1));
            _mockRepository.Verify(mock => mock.Add(It.IsAny<Location>()), Times.Exactly(1));
            _mockRepository.Verify(mock => mock.Save(), Times.Exactly(1));
        }

        protected override AddLocationCommandHandler CreateItemToTest()
        {
            return new AddLocationCommandHandler(_mockRepository.Object, _mockMapper.Object);
        }

        protected override void SetupMockingForTests()
        {
            _mockRepository = new Mock<IBaseRepository<Location>>();
            _mockMapper = new Mock<IMapper>();
        }
    }
}
