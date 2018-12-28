using Cqrs.Service.CommandContracts;
using Entity.Models;

namespace Cqrs.Service.Command
{
    public class UpdateTripCommand : ICommand
    {
        public UpdateTripCommand(TripDto trip)
        {
            Trip = trip;
        }

        public TripDto Trip{ get; set; }
    }
}
