using System;
using System.Collections.Generic;
using DomainModels;

namespace Entity.Models
{
    public class TripDto
    {
        public Guid Id { get; set; }

        public string FromLocation { get; set; }

        public string ToLocation { get; set; }

        public string HotelName { get; set; }

        public string AuthorInformation { get; set; }

        public double EstimateCost { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Type { get; set; }

        public int Status { get; set; }

        public List<EmployeeTripDto> EmployeeTrips { get; set; }

        public LocationDto Location { get; set; }
    }
}
