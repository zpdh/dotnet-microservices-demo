using Api.App.Core.Data;
using Api.Infrastructure.Core;

namespace Api.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>();
        services.AddScoped<IDbContext, AppDbContext>();
    }
}