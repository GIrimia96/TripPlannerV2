using System;

namespace Entity.Models
{
    //clasa pentru a putea avea @ManyToMany intre Emp si Trips
    public class EmployeeTrip : BaseEntity
    {
        public Guid EmployeeId { get; set; }
        public Guid TripId { get; set; }

        public Employee Employee { get; set; }
        public Trip Trip { get; set; }
    }
}
