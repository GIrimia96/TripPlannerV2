using System;
using System.Collections.Generic;

namespace Entity.Models
{
    public class Trip : BaseEntity
    {
        public string FromLocation { get; set; }

        public string ToLocation { get; set; }

        public string HotelName { get; set; }

        public string AuthorInformation { get; set; }

        public double EstimateCost { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Type { get; set; }

        public int Status { get; set; }

        public List<EmployeeTrip> EmployeeTrips { get; set; }

        public Location Location { get; set; }
    }
}
