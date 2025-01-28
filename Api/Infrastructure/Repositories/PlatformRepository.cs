using Api.Domain.Core;
using Api.Domain.Infrastructure.Data.Abstractions;
using Api.Domain.Platform;
using Api.Infrastructure.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace Api.Infrastructure.Repositories;

public class PlatformRepository(AppDbContext context) : IRepository<Platform>
{
    private readonly AppDbContext _context = context;

    public async Task<Result<Platform>> GetByIdAsync(int id)
    {
        return await _context.Set<Platform>().FirstOrDefaultAsync(plat => plat.Id == id);
    }
}