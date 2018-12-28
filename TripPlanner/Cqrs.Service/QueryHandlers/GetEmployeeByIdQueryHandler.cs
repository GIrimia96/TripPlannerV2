using AutoMapper;
using Cqrs.Service.Queries;
using Cqrs.Service.QueryContracts;
using Cqrs.Service.QueryResults;
using DomainModels;
using Entity.Models;
using Repositories.Contracts;

namespace Cqrs.Service.QueryHandlers
{
    public class GetEmployeeByIdQueryHandler : IQueryHandler<GetEmployeeByIdQuery, GetEmployeeByIdQueryResult>
    {
        private readonly IBaseRepository<Employee> repo;
        private readonly IMapper _mapper;

        public GetEmployeeByIdQueryHandler(IBaseRepository<Employee> repo, IMapper mapper)
        {
            this.repo = repo;
            _mapper = mapper;
        }


        public GetEmployeeByIdQueryResult Execute(GetEmployeeByIdQuery query)
        {
            var resource = repo.Get(query.Id);

            var employeeToReturn = _mapper.Map<Employee, EmployeeDto>(resource);
            return new GetEmployeeByIdQueryResult(employeeToReturn);
        }
    }
}
