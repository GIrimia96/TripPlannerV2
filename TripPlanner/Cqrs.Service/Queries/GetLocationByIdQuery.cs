using System;
using Cqrs.Service.QueryContracts;

namespace Cqrs.Service.Queries
{
    public class GetLocationByIdQuery : IQuery
    {
        public GetLocationByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
