using System.Collections.Generic;
using System.Linq;
using DomainModels;
using Entity.Models;

namespace Cqrs.Service.QueryHandlers
{
    using System;
    using AutoMapper;
    using Cqrs.Service.Queries;
    using Cqrs.Service.QueryContracts;
    using Cqrs.Service.QueryResults;
    using Repositories.Contracts;

    public class GetAllLocationsQueryHandler : IQueryHandler<GetAllLocationsQuery, GetAllLocationsQueryResult>
    {
        private readonly IBaseRepository<Location> repo;
        private readonly IMapper _mapper;

        public GetAllLocationsQueryHandler(IBaseRepository<Location> repo, IMapper mapper)
        {
            this.repo = repo;
            _mapper = mapper;
        }

        public GetAllLocationsQueryResult Execute(GetAllLocationsQuery query)
        {
            var result = this.repo.Query().ToList();

            return new GetAllLocationsQueryResult(result.Select(x => new LocationDto
            {
                Name = x.Name,
                Id = x.Id,
                Country = x.Country
            }));
        }
    }
}
