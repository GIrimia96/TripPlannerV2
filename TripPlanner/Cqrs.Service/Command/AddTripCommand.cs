using Cqrs.Service.CommandContracts;
using Entity.Models;

namespace Cqrs.Service.Command
{
    public class AddTripCommand : ICommand
    {
        public AddTripCommand(TripDto trip)
        {
            Trip = trip;
        }

        public TripDto Trip{ get; set; }
    }
}
