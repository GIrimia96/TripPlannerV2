using Cqrs.Service.CommandContracts;
using DomainModels;

namespace Cqrs.Service.Command
{
    public class AddLocationCommand : ICommand
    {
        public AddLocationCommand(LocationDto location)
        {
            Location = location;
        }

        public LocationDto Location { get; set; }
    }
}
