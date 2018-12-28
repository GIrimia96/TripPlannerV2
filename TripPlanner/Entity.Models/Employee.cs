using System.Collections.Generic;

namespace Entity.Models
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Title { get; set; }

        public string Role { get; set; }

        public List<EmployeeTrip> EmployeeTrips { get; set; }
    }
}
