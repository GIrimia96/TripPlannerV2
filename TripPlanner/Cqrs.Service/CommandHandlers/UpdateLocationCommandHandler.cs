using System;
using AutoMapper;
using Cqrs.Service.Command;
using Cqrs.Service.CommandContracts;
using Cqrs.Service.Exceptions;
using EnsureThat;
using Entity.Models;
using Repositories.Contracts;

namespace Cqrs.Service.CommandHandlers
{
    public class UpdateLocationCommandHandler : ICommandHandler<UpdateLocationCommand>
    {
        private readonly IBaseRepository<Location> repo;
        private readonly IMapper _mapper;

        public UpdateLocationCommandHandler(IMapper mapper, IBaseRepository<Location> repo)
        {
            _mapper = mapper;
            this.repo = repo;
        }

        public void Execute(UpdateLocationCommand command)
        {
            EnsureArg.IsNotNull(command);
            var location = repo.Get(command.Location.Id);

            if (location == null)
            {
                throw new GeneralBusinessException("Location cannot be empty");
            }
            _mapper.Map(command.Location, location);
            repo.Save();
        }
    }
}
