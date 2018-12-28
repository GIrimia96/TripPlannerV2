using Cqrs.Service.CommandContracts;
using Cqrs.Service.QueryContracts;
using Microsoft.AspNetCore.Mvc;

namespace TripPlanner.Api.Controllers
{
    public abstract class BaseController : Controller   
    {
        protected BaseController(ICommandDispatcher iCommandDispatcher, IQueryDispatcher iQueryDispatcher)
        {
            CommandDispatcher = iCommandDispatcher;
            QueryDispatcher = iQueryDispatcher;
        }

        protected ICommandDispatcher CommandDispatcher { get; }

        protected IQueryDispatcher QueryDispatcher { get; }
    }
}