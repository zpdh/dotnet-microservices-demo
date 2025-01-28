using Api.Domain.Core;
using Api.Domain.Infrastructure.Data.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Api.Infrastructure.Core;

public class UnitOfWork(DbContext context) : IUnitOfWork
{
    private readonly DbContext _context = context;

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}