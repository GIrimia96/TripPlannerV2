using AutoMapper;
using Cqrs.Service.Command;
using Cqrs.Service.CommandContracts;
using EnsureThat;
using Entity.Models;
using Repositories.Contracts;

namespace Cqrs.Service.CommandHandlers
{
    public class AddEmployeeCommandHandler : ICommandHandler<AddEmployeeCommand>
    {
        private readonly IBaseRepository<Employee> _baseRepo;
        private readonly IMapper _mapper;

        public AddEmployeeCommandHandler(IBaseRepository<Employee> baseRepository, IMapper mapper)
        {
            _baseRepo = baseRepository;
            _mapper = mapper;
        }

        public void Execute(AddEmployeeCommand command)
        {
            EnsureArg.IsNotNull(command);

            var mappedEmployee = new Employee();

            _mapper.Map(command.Employee, mappedEmployee);
            _baseRepo.Add(mappedEmployee);
            _baseRepo.Save();
        }
    }
}
