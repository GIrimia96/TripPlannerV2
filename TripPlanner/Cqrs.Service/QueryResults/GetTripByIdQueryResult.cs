using Cqrs.Service.QueryContracts;
using DomainModels;
using Entity.Models;

namespace Cqrs.Service.QueryResults
{
    public class GetTripByIdQueryResult : IQueryResult
    {
        public GetTripByIdQueryResult(TripDto trip)
        {
            Trip = trip;
        }

        public TripDto Trip{ get; set; }
    }
}
