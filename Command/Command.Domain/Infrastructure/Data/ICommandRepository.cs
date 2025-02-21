using Command.Domain.Core;
using Command.Domain.Infrastructure.Data.Abstractions;

namespace Command.Domain.Infrastructure.Data;

public interface ICommandRepository : IRepository<Command.Command>
{
    Task<Result<Command.Command>> GetByIdAsync(int id, int platformId);
    Task<Result> InsertAsync(Command.Command command, int platformId);
}