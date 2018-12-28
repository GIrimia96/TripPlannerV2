using AutoMapper;
using Cqrs.Service.Command;
using Cqrs.Service.CommandContracts;
using EnsureThat;
using Entity.Models;
using Repositories.Contracts;

namespace Cqrs.Service.CommandHandlers
{
    public class DeleteEmployeeCommandHandler : ICommandHandler<DeleteEmployeeCommand>
    {
        private readonly IBaseRepository<Employee> repo;

        public DeleteEmployeeCommandHandler(IBaseRepository<Employee> repo)
        {
            this.repo = repo;
        }


        public void Execute(DeleteEmployeeCommand command)
        {
            EnsureArg.IsNotNull(command);

            var employee = repo.Get(command.EmployeeId);
            Ensure.That(employee == null)
                .IsFalse();

            repo.Delete(employee);
            repo.Save();
        }
    }
}
