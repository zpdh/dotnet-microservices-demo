using Platform.Api.Domain.Platform;
using Platform.Api.Infrastructure.Core;
using Microsoft.EntityFrameworkCore;
using Platform.Api.Domain.Infrastructure.Data.Abstractions;
using Platform.Api.Infrastructure.Core.Data;
using Platform.Api.Infrastructure.Repositories;

namespace Platform.Api.Infrastructure;

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
        services.AddScoped<IRepository<Domain.Platform.Platform>, PlatformRepository>();
    }
}