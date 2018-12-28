using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Cqrs.Service.Queries;
using Cqrs.Service.QueryContracts;
using Cqrs.Service.QueryResults;
using DomainModels;
using Entity.Models;
using Repositories.Contracts;

namespace Cqrs.Service.QueryHandlers
{
    public class GetLocationByIdQueryHandler : IQueryHandler<GetLocationByIdQuery, GetLocationByIdQueryResult>
    {
        private readonly IBaseRepository<Location> repo;
        private readonly IMapper _mapper;

        public GetLocationByIdQueryHandler(IBaseRepository<Location> repo, IMapper mapper)
        {
            this.repo = repo;
            _mapper = mapper;
        }


        public GetLocationByIdQueryResult Execute(GetLocationByIdQuery query)
        {
            var resource = repo.Get(query.Id);

            var locationToReturn = _mapper.Map<Location, LocationDto>(resource);
            return new GetLocationByIdQueryResult(locationToReturn);
        }
    }
}
