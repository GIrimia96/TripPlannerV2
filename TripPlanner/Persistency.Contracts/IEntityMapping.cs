using Microsoft.EntityFrameworkCore;

namespace Persistency.Contracts
{
    public interface IEntityMapping
    {
        void Map(ModelBuilder modelBuilder);
    }
}
