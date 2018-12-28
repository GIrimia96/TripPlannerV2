using Cqrs.Service.CommandContracts;
using DomainModels;

namespace Cqrs.Service.Command
{
    public class UpdateLocationCommand : ICommand
    {
        public UpdateLocationCommand(LocationDto locationDto)
        {
            Location = locationDto;
        }

        public LocationDto Location { get; set; }

    }
}
