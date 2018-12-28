using Cqrs.Service.CommandContracts;
using DomainModels;

namespace Cqrs.Service.Command
{
    public class AddEmployeeCommand : ICommand
    {
        public AddEmployeeCommand(EmployeeDto employee)
        {
            Employee = employee;
        }

        public EmployeeDto Employee { get; set; }
    }
}
