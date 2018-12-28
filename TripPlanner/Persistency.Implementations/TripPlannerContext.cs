using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Persistency.Contracts;
using Persistency.Mappings.EntityMappings;
using System.Collections.Generic;

namespace Persistency.Implementations
{
    public class TripPlannerContext : DbContext
    {
        private readonly IEnumerable<IEntityMapping> _entityMappingCollection;

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Document> Documents { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Trip> Trips { get; set; }

        public TripPlannerContext(IEnumerable<IEntityMapping> entityMappingCollection, DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        {
            _entityMappingCollection = entityMappingCollection;
            Database.Migrate();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LocationMappings());
            modelBuilder.ApplyConfiguration(new TripMappings());
            modelBuilder.ApplyConfiguration(new EmployeeMappings());
            modelBuilder.ApplyConfiguration(new EmployeeTripMappings());
        }
    }
}
