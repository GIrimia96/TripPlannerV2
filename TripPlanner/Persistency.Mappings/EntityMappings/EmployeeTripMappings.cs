using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistency.Mappings.EntityMappings
{
    public class EmployeeTripMappings : IEntityTypeConfiguration<EmployeeTrip>
    {
        public void Configure(EntityTypeBuilder<EmployeeTrip> builder)
        {
            builder.HasKey(et => new {et.EmployeeId, et.TripId});
            builder.HasOne(et => et.Employee).WithMany(et => et.EmployeeTrips).HasForeignKey(et => et.EmployeeId);
            builder.HasOne(et => et.Trip).WithMany(et => et.EmployeeTrips).HasForeignKey(et => et.TripId);
        }
    }
}

