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
    public class UpdateEmployeeCommandHandler : ICommandHandler<UpdateEmployeeCommand>
    {
        private readonly IBaseRepository<Employee> repo;
        private readonly IMapper _mapper;

        public UpdateEmployeeCommandHandler(IMapper mapper, IBaseRepository<Employee> repo)
        {
            _mapper = mapper;
            this.repo = repo;
        }

        public void Execute(UpdateEmployeeCommand command)
        {
            EnsureArg.IsNotNull(command);
            var employee = repo.Get(command.Employee.Id);

            if (employee == null)
            {
                throw new GeneralBusinessException("Employee not found");
            }

            _mapper.Map(command.Employee, employee);
            repo.Save();
        }
    }
}
