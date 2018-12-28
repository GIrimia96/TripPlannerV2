using AutoMapper;
using Cqrs.Service.Queries;
using Cqrs.Service.QueryContracts;
using Cqrs.Service.QueryResults;
using Entity.Models;
using Repositories.Contracts;

namespace Cqrs.Service.QueryHandlers
{
    public class GetTripByIdQueryHandler : IQueryHandler<GetTripByIdQuery, GetTripByIdQueryResult>
    {
        private readonly IBaseRepository<Trip> repo;
        private readonly IMapper _mapper;

        public GetTripByIdQueryHandler(IBaseRepository<Trip> repo, IMapper mapper)
        {
            this.repo = repo;
            _mapper = mapper;
        }


        public GetTripByIdQueryResult Execute(GetTripByIdQuery query)
        {
            var resource = repo.Get(query.Id);

            var tripToReturn = _mapper.Map<Trip, TripDto>(resource);
            return new GetTripByIdQueryResult(tripToReturn);
        }
    }
}
