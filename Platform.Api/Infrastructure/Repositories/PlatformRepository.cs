using Platform.Api.Domain.Platform;
using Microsoft.EntityFrameworkCore;
using Platform.Api.Domain.Core;
using Platform.Api.Domain.Infrastructure.Data.Abstractions;
using Platform.Api.Infrastructure.Core.Data;

namespace Platform.Api.Infrastructure.Repositories;

public class PlatformRepository(AppDbContext context) : IRepository<Domain.Platform.Platform>
{
    private readonly DbSet<Domain.Platform.Platform> _dbSet = context.Set<Domain.Platform.Platform>();

    public async Task<Result<List<Domain.Platform.Platform>>> GetAllAsync()
    {
        return await _dbSet.AsNoTracking().ToListAsync();
    }

    public async Task<Result<Domain.Platform.Platform>> GetByIdAsync(int id)
    {
        return await _dbSet.FirstOrDefaultAsync(plat => plat.Id == id);
    }

    public async Task InsertAsync(Domain.Platform.Platform entity)
    {
        await _dbSet.AddAsync(entity);
    }
}