using System;
using Cqrs.Service.QueryContracts;

namespace Cqrs.Service.Queries
{
    public class GetEmployeeByIdQuery : IQuery
    {
        public GetEmployeeByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
