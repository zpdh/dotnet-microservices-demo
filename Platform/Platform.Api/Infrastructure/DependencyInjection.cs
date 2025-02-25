using Platform.Api.Domain.Platform;
using Microsoft.EntityFrameworkCore;
using Platform.Api.Domain.Infrastructure.Data.Abstractions;
using Platform.Api.Domain.Infrastructure.MessageBus;
using Platform.Api.Infrastructure.Core.Data;
using Platform.Api.Infrastructure.HttpClients;
using Platform.Api.Infrastructure.Messaging;
using Platform.Api.Infrastructure.Repositories;
using RabbitMQ.Client;

namespace Platform.Api.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
    {
        services.AddDatabase(configuration, environment);
        services.AddRepositories();
        services.AddHttpClients(configuration);
    }

    private static void AddDatabase(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
    {
        if (!environment.IsDevelopment())
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("MSSQL")));
        }
        else
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("MemDb"));
        }
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IRepository<Domain.Platform.Platform>, PlatformRepository>();
    }

    private static void AddHttpClients(this IServiceCollection services, IConfiguration configuration)
    {
        var commandUri = configuration["Urls:CommandsService"]!;

        services.AddHttpClient<IPlatformClient, PlatformClient>(client => client.BaseAddress = new Uri(commandUri));
    }

    private static void AddEventBus(this IServiceCollection services, IConfiguration configuration)
    {
        var host = configuration.GetValue<string>("Events:RabbitMQHost")!;
        var port = configuration.GetValue<int>("Events:RabbitMQPort");

        var connectionFactory = new ConnectionFactory { HostName = host, Port = port };

        services.AddSingleton<IEventPublisher, EventPublisher>(_ => new EventPublisher(connectionFactory));
        services.AddScoped<IEventBus, EventBus>();
    }
}