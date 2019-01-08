using System;
using Cqrs.Service.CommandContracts;
using Cqrs.Service.QueryContracts;
using Cqrs.Service.Command;
using Cqrs.Service.Queries;
using Cqrs.Service.QueryResults;
using Microsoft.AspNetCore.Mvc;
using DomainModels;
using EnsureThat;

namespace TripPlanner.Api.Controllers
{
    [Route("api/location")]
    //[EnableCors("TripPlanner")]
    public class LocationController : BaseController
    {
        public LocationController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
            : base(commandDispatcher, queryDispatcher)
        {
        }

        [HttpGet("{locationId}")]
        public IActionResult Index(Guid locationId)
        {
            EnsureArg.IsNotEmpty(locationId);
            var query = new GetLocationByIdQuery(locationId);
            var queryResult = QueryDispatcher.Execute<GetLocationByIdQuery, GetLocationByIdQueryResult>(query);

            return Ok(queryResult.Location);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var query = new GetAllLocationsQuery();
            var queryResult = QueryDispatcher.Execute<GetAllLocationsQuery, GetAllLocationsQueryResult> (query);

            return Ok(queryResult.Locations);
        }

        [HttpPost]
        public IActionResult AddLocation([FromBody] LocationDto locationDto)
        {
            EnsureArg.IsNotNull(locationDto);

            var command = new AddLocationCommand(locationDto);

            CommandDispatcher.Execute(command);
            return NoContent();
        }

        [HttpPut]
        public IActionResult UpdateLocation([FromBody] LocationDto locationDto)
        {
            EnsureArg.IsNotNull(locationDto);
            var command = new UpdateLocationCommand(locationDto);
            CommandDispatcher.Execute(command);

            return NoContent();
        }

        [HttpDelete("{locationId}")]
        public IActionResult DeleteLocation(Guid locationId)
        {
            EnsureArg.IsNotEmpty(locationId);

            var command = new DeleteLocationCommand(locationId);
            CommandDispatcher.Execute(command);

            return NoContent();
        }

    }
}