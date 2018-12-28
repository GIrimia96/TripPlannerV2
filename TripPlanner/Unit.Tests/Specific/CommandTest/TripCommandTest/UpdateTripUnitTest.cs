using System;
using AutoMapper;
using Cqrs.Service.Command;
using Cqrs.Service.CommandHandlers;
using Cqrs.Service.Exceptions;
using Entity.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Repositories.Contracts;
using Unit.Tests.Generic;

namespace Unit.Tests.Specific.CommandTest.EmployeeCommandTest
{
    [TestClass]
    public class UpdateTripUnitTest : BaseTest<UpdateTripCommandHandler>
    {
        private Mock<IBaseRepository<Trip>> _mockRepository;
        private Mock<IMapper> _mockMapper;
        private Trip _trip;
        private TripDto _tripDto;

        [TestMethod]
        public void UpdateTrip_ThrowsException_WhenParameterIsNull()
        {
            Action check = () => { CreateItemToTest().Execute(null); };
            check.Should().Throw<ArgumentNullException>();
        }


        [TestMethod]
        public void UpdateTrip_ShouldThrowError_WhenTripNotFound()
        {
            Action check = () => { CreateItemToTest().Execute(new UpdateTripCommand(new TripDto())); };
            check.Should().Throw<GeneralBusinessException>().WithMessage("Trip cannot be null");
        }

        [TestMethod]
        public void UpdateETrip_ShouldUpdateTrip()
        {
            MockTrip(_trip);
            CreateItemToTest().Execute(new UpdateTripCommand(_tripDto));

            _mockMapper.Verify(mock => mock.Map(It.IsAny<TripDto>(), It.IsAny<Trip>()), Times.Exactly(1));
            _mockRepository.Verify(mock => mock.Save(), Times.Exactly(1));
        }

        private void MockTrip(Trip trip)
        {
            _mockRepository.Setup(x => x.Get(trip.Id))
                .Returns(trip);
        }

        protected override void SetupMockingForTests()
        {
            _mockRepository = new Mock<IBaseRepository<Trip>>();
            _mockMapper = new Mock<IMapper>();
            _trip = new Trip
            {
                Id = Guid.NewGuid()
            };

            _tripDto = new TripDto
            {
                Id = _trip.Id
            };
        }



        protected override UpdateTripCommandHandler CreateItemToTest()
        {
            return new UpdateTripCommandHandler(_mockMapper.Object, _mockRepository.Object);
        }
    }
}
