using AutoMapper;
using Cqrs.Service.Command;
using Cqrs.Service.CommandContracts;
using Cqrs.Service.Exceptions;
using EnsureThat;
using Entity.Models;
using Repositories.Contracts;

namespace Cqrs.Service.CommandHandlers
{
    public class UpdateTripCommandHandler : ICommandHandler<UpdateTripCommand>
    {
        private readonly IBaseRepository<Trip> repo;
        private readonly IMapper _mapper;

        public UpdateTripCommandHandler(IMapper mapper, IBaseRepository<Trip> repo)
        {
            _mapper = mapper;
            this.repo = repo;
        }

        public void Execute(UpdateTripCommand command)
        {
            EnsureArg.IsNotNull(command);
            var trip = repo.Get(command.Trip.Id);

            if (trip == null)
            {
                throw new GeneralBusinessException("Trip cannot be null");
            }

            _mapper.Map(command.Trip, trip);
            repo.Save();
        }
    }
}
