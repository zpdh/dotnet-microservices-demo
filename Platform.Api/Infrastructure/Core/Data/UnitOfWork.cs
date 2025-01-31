using Platform.Api.Domain.Infrastructure.Data.Abstractions;

namespace Platform.Api.Infrastructure.Core.Data;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    private readonly AppDbContext _context = context;

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}