using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Command.Infrastructure;

public static class Infrastructure
{
    public static readonly Assembly Assembly = typeof(Infrastructure).Assembly;

    public static void InjectInfrastructure(this IServiceCollection services)
    {

    }
}