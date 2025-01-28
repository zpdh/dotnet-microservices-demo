using Api.App.Core.Data;
using Api.Domain.Core;
using Api.Domain.Platform;
using Microsoft.EntityFrameworkCore;

namespace Api.Infrastructure.Core;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options), IDbContext
{
    public new DbSet<TEntity> Set<TEntity>()
        where TEntity : Entity
    {
        return base.Set<TEntity>();
    }

    public async Task<Result<TEntity>> GetByIdAsync<TEntity>(int id)
        where TEntity : Entity
    {
        return await Set<TEntity>().FirstOrDefaultAsync(entity => entity.Id == id);
    }

    public Task<Result<TEntity>> InsertAsync<TEntity>(TEntity entity)
        where TEntity : Entity
    {
        throw new NotImplementedException();
    }

    public Task<Result<TEntity>> RemoveAsync<TEntity>(TEntity entity)
        where TEntity : Entity
    {
        throw new NotImplementedException();
    }
}