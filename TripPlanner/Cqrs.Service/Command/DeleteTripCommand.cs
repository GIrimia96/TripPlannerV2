using System;
using Cqrs.Service.CommandContracts;

namespace Cqrs.Service.Command
{
    public class DeleteTripCommand : ICommand
    {
        public DeleteTripCommand(Guid id)
        {
           TripId = id;
        }

        public Guid TripId { get; set; }

    }
}
