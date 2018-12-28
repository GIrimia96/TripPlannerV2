using AutoMapper;
using Cqrs.Service.Command;
using Cqrs.Service.CommandContracts;
using EnsureThat;
using Entity.Models;
using Repositories.Contracts;

namespace Cqrs.Service.CommandHandlers
{
    public class AddTripCommandHandler : ICommandHandler<AddTripCommand>
    {
        private readonly IBaseRepository<Trip> _baseRepo;
        private readonly IMapper _mapper;

        public AddTripCommandHandler(IBaseRepository<Trip> baseRepository, IMapper mapper)
        {
            _baseRepo = baseRepository;
            _mapper = mapper;
        }

        public void Execute(AddTripCommand command)
        {
            EnsureArg.IsNotNull(command);

            var mappedTrip = new Trip();

            _mapper.Map(command.Trip, mappedTrip);
            _baseRepo.Add(mappedTrip);
            _baseRepo.Save();
        }
    }
}
