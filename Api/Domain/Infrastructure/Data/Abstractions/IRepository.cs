using Api.Domain.Core;

namespace Api.Domain.Infrastructure.Data.Abstractions;

public interface IRepository<TEntity> where TEntity : Entity
{
    Task<Result<TEntity>> GetByIdAsync(int id);
}