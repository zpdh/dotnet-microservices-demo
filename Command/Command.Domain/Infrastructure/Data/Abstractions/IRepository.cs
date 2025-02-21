using Command.Domain.Core;

namespace Command.Domain.Infrastructure.Data.Abstractions;

public interface IRepository<TEntity> where TEntity : Entity
{
}