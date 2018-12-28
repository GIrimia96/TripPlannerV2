using AutoMapper;
using Cqrs.Service.Command;
using Cqrs.Service.CommandContracts;
using EnsureThat;
using Entity.Models;
using Repositories.Contracts;

namespace Cqrs.Service.CommandHandlers
{
    public class AddLocationCommandHandler : ICommandHandler<AddLocationCommand>
    {
        private readonly IBaseRepository<Location> _baseRepo;
        private readonly IMapper _mapper;

        public AddLocationCommandHandler(IBaseRepository<Location> baseRepository, IMapper mapper)
        {
            _baseRepo = baseRepository;
            _mapper = mapper;
        }

        public void Execute(AddLocationCommand command)
        {
            EnsureArg.IsNotNull(command);

            var mappedLocation = new Location();

            _mapper.Map(command.Location, mappedLocation);
            _baseRepo.Add(mappedLocation);
            _baseRepo.Save();
        }
    }
}
