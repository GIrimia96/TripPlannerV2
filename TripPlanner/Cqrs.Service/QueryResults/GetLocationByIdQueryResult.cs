using Cqrs.Service.QueryContracts;
using DomainModels;

namespace Cqrs.Service.QueryResults
{
    public class GetLocationByIdQueryResult : IQueryResult
    {
        public GetLocationByIdQueryResult(LocationDto location)
        {
            Location = location;
        }

        public LocationDto Location { get; set; }
    }
}
