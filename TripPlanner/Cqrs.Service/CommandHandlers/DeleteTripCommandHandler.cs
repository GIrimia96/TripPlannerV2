using AutoMapper;
using Cqrs.Service.Command;
using Cqrs.Service.CommandContracts;
using EnsureThat;
using Entity.Models;
using Repositories.Contracts;

namespace Cqrs.Service.CommandHandlers
{
    public class DeleteTripCommandHandler : ICommandHandler<DeleteTripCommand>
    {
        private readonly IBaseRepository<Trip> repo;

        public DeleteTripCommandHandler(IBaseRepository<Trip> repo)
        {
            this.repo = repo;
        }


        public void Execute(DeleteTripCommand command)
        {
            EnsureArg.IsNotNull(command);

            var trip = repo.Get(command.TripId);
            Ensure.That(trip == null)
                .IsFalse();

            repo.Delete(trip);
            repo.Save();
        }
    }
}
