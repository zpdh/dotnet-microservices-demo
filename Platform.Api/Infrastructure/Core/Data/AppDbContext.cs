using Platform.Api.Domain.Platform;
using Microsoft.EntityFrameworkCore;
using Platform.Api.Domain.Core;

namespace Platform.Api.Infrastructure.Core.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public new DbSet<TEntity> Set<TEntity>()
        where TEntity : Entity
    {
        return base.Set<TEntity>();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}