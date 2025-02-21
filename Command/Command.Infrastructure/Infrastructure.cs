using System.Reflection;
using Command.Domain.Infrastructure.Data.Abstractions;
using Command.Domain.Platform;
using Command.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Command.Infrastructure;

public static class Infrastructure
{
    public static readonly Assembly Assembly = typeof(Infrastructure).Assembly;

    public static void InjectInfrastructure(this IServiceCollection services)
    {
        services.InjectRepositories();
    }

    private static void InjectRepositories(this IServiceCollection services)
    {
        services.AddScoped<IRepository<Domain.Command.Command>, CommandRepository>();
        services.AddScoped<IRepository<Platform>, PlatformRepository>();
    }
}