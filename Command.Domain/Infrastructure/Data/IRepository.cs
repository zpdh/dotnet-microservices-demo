using Command.Domain.Core;

namespace Command.Domain.Infrastructure.Data;

public interface IRepository<TEntity> where TEntity : Entity
{
    Task<Result<List<TEntity>>> GetAllAsync();
    Task<Result<TEntity>> GetByIdAsync(int id);
    Task InsertAsync(TEntity entity);
}