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

namespace Unit.Tests.Specific.CommandTest.LocationCommandTest
{
    [TestClass]
    public class UpdateLocationUnitTest : BaseTest<UpdateLocationCommandHandler>
    {
        private Mock<IMapper> _mockMapper;
        private Mock<IBaseRepository<Location>> _mockRepository;
        private Location _location;
        private LocationDto _locationDto;

        [TestMethod]
        public void UpdateLocation_ShouldThrowException_WhenCommandIsNull()
        {
            Action check = () => { CreateItemToTest().Execute(null); };
            check.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void UpdateLocation_ShouldUpdateLocation()
        {
            MockLocation(_location);
            CreateItemToTest().Execute(new UpdateLocationCommand(_locationDto));

            _mockMapper.Verify(mock => mock.Map(It.IsAny<LocationDto>(), It.IsAny<Location>()), Times.Exactly(1));
            _mockRepository.Verify(mock => mock.Save());
        }

        [TestMethod]
        public void UpdateLocation_ShouldThrowException_WhenEntityNotFoundInDB()
        {
            Action check = () => { CreateItemToTest().Execute(new UpdateLocationCommand(new LocationDto())); };
            check.Should().Throw<GeneralBusinessException>().WithMessage("Location cannot be empty");
        }

        private void MockLocation(Location location)
        {
            _mockRepository.Setup(mock => mock.Get(location.Id)).Returns(location);
        }

        protected override UpdateLocationCommandHandler CreateItemToTest()
        {
            return new UpdateLocationCommandHandler(_mockMapper.Object, _mockRepository.Object);
        }

        protected override void SetupMockingForTests()
        {
            _mockRepository = new Mock<IBaseRepository<Location>>();
            _mockMapper = new Mock<IMapper>();
            _location = new Location
            {
                Id = Guid.NewGuid()
            };
            _locationDto = new LocationDto
            {
                Id =  _location.Id
            };

        }
    }
}
