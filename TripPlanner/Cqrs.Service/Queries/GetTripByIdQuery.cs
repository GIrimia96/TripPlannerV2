using System;
using Cqrs.Service.QueryContracts;

namespace Cqrs.Service.Queries
{
    public class GetTripByIdQuery : IQuery
    {
        public GetTripByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
