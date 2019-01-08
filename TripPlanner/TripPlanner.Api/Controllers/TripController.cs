using System;
using Cqrs.Service.CommandContracts;
using Cqrs.Service.QueryContracts;
using Cqrs.Service.Command;
using Cqrs.Service.Queries;
using Cqrs.Service.QueryResults;
using Microsoft.AspNetCore.Mvc;
using DomainModels;
using EnsureThat;
using Entity.Models;

namespace TripPlanner.Api.Controllers
{
    [Route("api/trip")]
    public class TripController : BaseController
    {
        public TripController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
            : base(commandDispatcher, queryDispatcher)
        {
        }

        [HttpGet("{tripId}")]
        public IActionResult Index(Guid tripId)
        {
            EnsureArg.IsNotEmpty(tripId);
            var query = new GetTripByIdQuery(tripId);
            var queryResult = QueryDispatcher.Execute<GetTripByIdQuery, GetTripByIdQueryResult>(query);

            return Ok(queryResult.Trip);
        }

        [HttpPost]
        public IActionResult AddTrip([FromBody] TripDto tripDto)
        {
            EnsureArg.IsNotNull(tripDto);

            var command = new AddTripCommand(tripDto);

            CommandDispatcher.Execute(command);
            return NoContent();
        }

        [HttpPut]
        public IActionResult UpdateTrip([FromBody] TripDto tripDto)
        {
            EnsureArg.IsNotNull(tripDto);
            var command = new UpdateTripCommand(tripDto);
            CommandDispatcher.Execute(command);

            return NoContent();
        }

        [HttpDelete("{tripId}")]
        public IActionResult DeleteLocation(Guid tripId)
        {
            EnsureArg.IsNotEmpty(tripId);

            var command = new DeleteTripCommand(tripId);
            CommandDispatcher.Execute(command);

            return NoContent();
        }

        [HttpGet]
        public IActionResult GetAllTrips()
        {
            var query = new GetAllTripsQuery();
            var queryResult = QueryDispatcher.Execute<GetAllTripsQuery, GetAllTripsQueryResult>(query);

            return Ok(queryResult.Trips);
        }

    }
}