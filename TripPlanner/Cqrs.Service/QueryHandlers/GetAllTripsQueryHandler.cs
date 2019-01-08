using System.Linq;
using Cqrs.Service.Queries;
using Cqrs.Service.QueryContracts;
using Cqrs.Service.QueryResults;
using Entity.Models;
using Repositories.Contracts;

namespace Cqrs.Service.QueryHandlers
{
    public class GetAllTripsQueryHandler : IQueryHandler<GetAllTripsQuery, GetAllTripsQueryResult>
    {
        private readonly IBaseRepository<Trip> tripRepository;

        public GetAllTripsQueryHandler(IBaseRepository<Trip> tripRepository)
        {
            this.tripRepository = tripRepository;
        }

        public GetAllTripsQueryResult Execute(GetAllTripsQuery query)
        {
            var trips = tripRepository.Query().ToList();

            return new GetAllTripsQueryResult(trips.Select(x => new TripDto
            {
                Id = x.Id,
                EndDate = x.EndDate,
                FromLocation = x.FromLocation,
                HotelName = x.HotelName,
                StartDate = x.StartDate,
                AuthorInformation = x.AuthorInformation,
                Status = x.Status,
                ToLocation = x.ToLocation,
                Type = x.Type,
                EstimateCost = x.EstimateCost
            }));

        }
    }
}
