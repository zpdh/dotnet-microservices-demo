using Command.Domain.Core;
using Command.Domain.Infrastructure.Data;
using Command.Domain.Platform;
using Command.Infrastructure.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace Command.Infrastructure.Repositories;

public class PlatformRepository(AppDbContext context) : IPlatformRepository
{
    private readonly DbSet<Platform> _platformSet = context.Set<Platform>();
    private readonly DbSet<Domain.Command.Command> _commandSet = context.Set<Domain.Command.Command>();

    public async Task<Result<List<Platform>>> GetAllAsync()
    {
        return await _platformSet.ToListAsync();
    }

    public async Task<Result> InsertAsync(Platform platform)
    {
        await _platformSet.AddAsync(platform);

        return Result.Success();
    }

    public async Task<bool> PlatformExistsAsync(int platformId)
    {
        return await _platformSet.AnyAsync(plat => plat.Id == platformId);
    }

    public async Task<List<Domain.Command.Command>> GetCommandsAsync(int platformId)
    {
        return await _commandSet.Where(cmd => cmd.PlatformId == platformId).ToListAsync();
    }
}