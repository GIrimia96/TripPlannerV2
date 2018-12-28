using Cqrs.Service.QueryContracts;
using DomainModels;

namespace Cqrs.Service.QueryResults
{
    public class GetEmployeeByIdQueryResult : IQueryResult
    {
        public GetEmployeeByIdQueryResult(EmployeeDto employee)
        {
            Employee = employee;
        }

        public EmployeeDto Employee { get; set; }
    }
}
