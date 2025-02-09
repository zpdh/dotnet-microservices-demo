using Platform.Api.Domain.Platform;
using Microsoft.EntityFrameworkCore;
using Platform.Api.Domain.Infrastructure.Data.Abstractions;
using Platform.Api.Infrastructure.Core.Data;
using Platform.Api.Infrastructure.HttpClients;
using Platform.Api.Infrastructure.Repositories;

namespace Platform.Api.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddDatabase();
        services.AddRepositories();
        services.AddHttpClients();
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

    private static void AddHttpClients(this IServiceCollection services)
    {
        services.AddHttpClient<IPlatformClient, PlatformClient>();
    }
}