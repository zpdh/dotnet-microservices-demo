using Api.Domain.Core;
using Microsoft.EntityFrameworkCore;

namespace Api.App.Core.Data;

public interface IDbContext
{
    DbSet<TEntity> Set<TEntity>()
        where TEntity : Entity;

    Task<Result<TEntity>> GetByIdAsync<TEntity>(int id)
        where TEntity : Entity;

    Task<Result<TEntity>> InsertAsync<TEntity>(TEntity entity)
        where TEntity : Entity;

    Task<Result<TEntity>> RemoveAsync<TEntity>(TEntity entity)
        where TEntity : Entity;
}