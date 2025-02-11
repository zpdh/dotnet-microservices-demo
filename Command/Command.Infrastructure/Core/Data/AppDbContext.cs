using Command.Domain.Core;
using Microsoft.EntityFrameworkCore;

namespace Command.Infrastructure.Core.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public new DbSet<TEntity> Set<TEntity>()
        where TEntity : Entity
    {
        return base.Set<TEntity>();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Infrastructure.Assembly);
        base.OnModelCreating(modelBuilder);
    }
}