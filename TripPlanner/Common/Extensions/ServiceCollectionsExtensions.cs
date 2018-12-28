using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistency.Implementations;

namespace Common.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDatabase(this IServiceCollection serviceCollection, string connectionString)
        {
            serviceCollection.AddEntityFrameworkSqlServer().AddDbContext<TripPlannerContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
