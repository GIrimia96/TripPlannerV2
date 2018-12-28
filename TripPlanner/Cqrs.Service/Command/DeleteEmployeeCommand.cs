using System;
using Cqrs.Service.CommandContracts;

namespace Cqrs.Service.Command
{
    public class DeleteEmployeeCommand : ICommand
    {
        public DeleteEmployeeCommand(Guid id)
        {
            EmployeeId = id;
        }

        public Guid EmployeeId { get; set; }

    }
}
