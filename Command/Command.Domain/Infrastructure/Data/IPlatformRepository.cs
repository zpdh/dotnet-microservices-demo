using Command.Domain.Core;
using Command.Domain.Infrastructure.Data.Abstractions;

namespace Command.Domain.Infrastructure.Data;

public interface IPlatformRepository : IRepository<Platform.Platform>
{
    Task<Result<List<Platform.Platform>>> GetAllAsync();
    Task<Result> InsertAsync(Platform.Platform platform);
    Task<bool> PlatformExistsAsync(int platformId);
}