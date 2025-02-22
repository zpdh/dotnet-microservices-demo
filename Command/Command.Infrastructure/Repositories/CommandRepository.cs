using Command.Domain.Core;
using Command.Domain.Infrastructure.Data;
using Command.Domain.Platform;
using Command.Infrastructure.Core.Data;
using Microsoft.EntityFrameworkCore;
using AppDomain = Command.Domain.Command;

namespace Command.Infrastructure.Repositories;

public sealed class CommandRepository(AppDbContext context) : ICommandRepository
{
    private readonly DbSet<AppDomain.Command> _commandSet = context.Set<AppDomain.Command>();
    private readonly DbSet<Platform> _platformSet = context.Set<Platform>();

    public async Task<Result<AppDomain.Command>> GetByIdAsync(int id, int platformId)
    {
        return await _commandSet.FirstOrDefaultAsync(cmd => cmd.PlatformId == platformId && cmd.Id == id);
    }

    public async Task<Result> InsertAsync(AppDomain.Command command, int platformId)
    {
        var platform = await _platformSet.FindAsync(platformId);

        if (platform is null)
        {
            return Result.Failure(AppDomain.Errors.Command.PlatformDoesntExist(platformId));
        }

        await _commandSet.AddAsync(command);

        return Result.Success();
    }

    public async Task<List<AppDomain.Command>> GetAllCommandsAsync(int platformId)
    {
        return await _commandSet.Where(cmd => cmd.PlatformId == platformId).ToListAsync();
    }
}