using Command.Domain.Core;
using Command.Domain.Infrastructure.Data;
using AppDomain = Command.Domain.Command;

namespace Command.Infrastructure.Repositories;

public sealed class CommandRepository : IRepository<AppDomain.Command>
{
    public Task<Result<List<AppDomain.Command>>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Result<AppDomain.Command>> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task InsertAsync(AppDomain.Command entity)
    {
        throw new NotImplementedException();
    }
}