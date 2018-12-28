namespace Cqrs.Service.QueryResults
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Cqrs.Service.QueryContracts;
    using DomainModels;

    public class GetAllLocationsQueryResult : IQueryResult
    {
        public GetAllLocationsQueryResult(IEnumerable<LocationDto> locationDto)
        {
            Locations = locationDto;
        }

        public IEnumerable<LocationDto> Locations { get; set; }
    }
}
