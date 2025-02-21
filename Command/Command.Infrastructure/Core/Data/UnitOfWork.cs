using Command.Domain.Infrastructure.Data;
using Command.Domain.Infrastructure.Data.Abstractions;

namespace Command.Infrastructure.Core.Data;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    private readonly AppDbContext _context = context;

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}