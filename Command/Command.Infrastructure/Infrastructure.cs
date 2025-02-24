using System.Reflection;
using Command.Domain.Infrastructure.Data;
using Command.Domain.Infrastructure.Data.Abstractions;
using Command.Domain.Platform;
using Command.Infrastructure.Core.Data;
using Command.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Command.Infrastructure;

public static class Infrastructure
{
    public static readonly Assembly Assembly = typeof(Infrastructure).Assembly;

    public static void InjectInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext();
        services.InjectRepositories();
    }

    private static void AddDbContext(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("CmdMemDb"));
    }
    
    private static void InjectRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICommandRepository, CommandRepository>();
        services.AddScoped<IPlatformRepository, PlatformRepository>();
    }
}