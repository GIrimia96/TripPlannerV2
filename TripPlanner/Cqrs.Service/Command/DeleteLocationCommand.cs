using System;
using Cqrs.Service.CommandContracts;

namespace Cqrs.Service.Command
{
    public class DeleteLocationCommand : ICommand
    {
        public DeleteLocationCommand(Guid id)
        {
            LocationId = id;
        }

        public Guid LocationId { get; set; }

    }
}
