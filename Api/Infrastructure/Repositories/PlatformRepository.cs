using Api.Domain.Core;
using Api.Domain.Infrastructure.Data.Abstractions;
using Api.Domain.Platform;
using Api.Infrastructure.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace Api.Infrastructure.Repositories;

public class PlatformRepository(AppDbContext context) : IRepository<Platform>
{
    private readonly DbSet<Platform> _dbSet = context.Set<Platform>();

    public async Task<Result<Platform>> GetByIdAsync(int id)
    {
        return await _dbSet.FirstOrDefaultAsync(plat => plat.Id == id);
    }
}