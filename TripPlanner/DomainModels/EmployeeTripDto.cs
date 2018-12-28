using System;
using System.Collections.Generic;
using System.Text;
using Entity.Models;

namespace DomainModels
{
    public class EmployeeTripDto
    {
        public Guid Id { get; set; }

        public Guid EmployeeId { get; set; }
        public Guid TripId { get; set; }

        public EmployeeDto Employee { get; set; }
        public TripDto Trip { get; set; }
    }
}
