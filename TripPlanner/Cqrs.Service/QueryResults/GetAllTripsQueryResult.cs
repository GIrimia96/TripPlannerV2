using Entity.Models;

namespace Cqrs.Service.QueryResults
{
    using System.Collections.Generic;
    using Cqrs.Service.QueryContracts;

    public class GetAllTripsQueryResult : IQueryResult
    {
        public GetAllTripsQueryResult(IEnumerable<TripDto> trips)
        {
            Trips = trips;
        }


        public IEnumerable<TripDto> Trips { get; set; }
    }
}
