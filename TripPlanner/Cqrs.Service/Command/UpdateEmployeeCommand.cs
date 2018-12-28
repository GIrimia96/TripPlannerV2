using Cqrs.Service.CommandContracts;
using DomainModels;

namespace Cqrs.Service.Command
{
    public class UpdateEmployeeCommand : ICommand
    {
        public UpdateEmployeeCommand(EmployeeDto employee)
        {
            Employee = employee;
        }

        public EmployeeDto Employee{ get; set; }

    }
}
