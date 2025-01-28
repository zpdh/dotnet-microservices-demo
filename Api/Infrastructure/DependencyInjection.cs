using Api.Domain.Infrastructure.Data.Abstractions;
using Api.Domain.Platform;
using Api.Infrastructure.Core;
using Api.Infrastructure.Core.Data;
using Api.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Api.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddDatabase();
        services.AddRepositories();
    }

    private static void AddDatabase(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("MemDb"));
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IRepository<Platform>, PlatformRepository>();
    }
}