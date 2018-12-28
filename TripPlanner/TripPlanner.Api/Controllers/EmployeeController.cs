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
    [Route("api/employee")]
    public class EmployeeController : BaseController
    {
        public EmployeeController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
            : base(commandDispatcher, queryDispatcher)
        {
        }

        [HttpGet("{employeeId}")]
        public IActionResult Index(Guid employeeId)
        {
            EnsureArg.IsNotEmpty(employeeId);
            var query = new GetEmployeeByIdQuery(employeeId);
            var queryResult = QueryDispatcher.Execute<GetEmployeeByIdQuery, GetEmployeeByIdQueryResult>(query);

            return Ok(queryResult.Employee);
        }

        [HttpPost]
        public IActionResult AddEmployee([FromBody] EmployeeDto employeeDto)
        {
            EnsureArg.IsNotNull(employeeDto);

            var command = new AddEmployeeCommand(employeeDto);

            CommandDispatcher.Execute(command);
            return NoContent();
        }

        [HttpPut]
        public IActionResult UpdateEmployee([FromBody] EmployeeDto employeeDto)
        {
            EnsureArg.IsNotNull(employeeDto);
            var command = new UpdateEmployeeCommand(employeeDto);
            CommandDispatcher.Execute(command);

            return NoContent();
        }

        [HttpDelete("{employeeId}")]
        public IActionResult DeleteLocation(Guid employeeId)
        {
            EnsureArg.IsNotEmpty(employeeId);

            var command = new DeleteEmployeeCommand(employeeId);
            CommandDispatcher.Execute(command);

            return NoContent();
        }

    }
}