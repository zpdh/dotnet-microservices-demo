using Api.Domain.Core;
using Microsoft.EntityFrameworkCore;

namespace Api.Infrastructure.Core.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public new DbSet<TEntity> Set<TEntity>()
        where TEntity : Entity
    {
        return base.Set<TEntity>();
    }
}