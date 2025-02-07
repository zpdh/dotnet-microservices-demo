using Command.Domain.Core;
using Command.Domain.Infrastructure.Data;
using Cmd = Command.Domain.Command;

namespace Command.Infrastructure.Repositories;

/* Cmd -> Namespace Alias */
public sealed class CommandRepository : IRepository<Cmd.Command>
{
    public Task<Result<List<Cmd.Command>>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Result<Cmd.Command>> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task InsertAsync(Cmd.Command entity)
    {
        throw new NotImplementedException();
    }
}