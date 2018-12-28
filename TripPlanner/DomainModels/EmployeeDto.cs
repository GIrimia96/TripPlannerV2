using System;
using System.Collections.Generic;

namespace DomainModels
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Title { get; set; }

        public string Role { get; set; }

        public List<EmployeeTripDto> EmployeeTrips { get; set; }
    }
}
