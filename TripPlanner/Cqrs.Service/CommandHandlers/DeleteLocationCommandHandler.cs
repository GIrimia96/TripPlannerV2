using AutoMapper;
using Cqrs.Service.Command;
using Cqrs.Service.CommandContracts;
using EnsureThat;
using Entity.Models;
using Repositories.Contracts;

namespace Cqrs.Service.CommandHandlers
{
    public class DeleteLocationCommandHandler : ICommandHandler<DeleteLocationCommand>
    {
        private readonly IBaseRepository<Location> repo;

        public DeleteLocationCommandHandler(IBaseRepository<Location> repo)
        {
            this.repo = repo;
        }


        public void Execute(DeleteLocationCommand command)
        {
            EnsureArg.IsNotNull(command);

            var location = repo.Get(command.LocationId);
            Ensure.That(location == null)
                .IsFalse();

            repo.Delete(location);
            repo.Save();
        }
    }
}
