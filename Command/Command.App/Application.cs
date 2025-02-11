using System.Reflection;
using Command.App.Core.Messaging;
using Command.App.Core.Messaging.Abstractions;
using Command.App.Core.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Command.App;

public static class Application
{
    public static readonly Assembly Assembly = typeof(Application).Assembly;

    public static void InjectApplication(this IServiceCollection services)
    {
        services.AddRequestHandlers();
        services.AddMediator();
    }

    private static void AddMediator(this IServiceCollection services)
    {
        services.AddScoped<IMediator, Mediator>();
    }

    private static void AddRequestHandlers(this IServiceCollection services)
    {
        var commandHandlerTypes = GetHandlerTypes(
            typeof(IRequestHandler<>),
            typeof(IRequestHandler<,>));

        foreach (var handlerGroup in commandHandlerTypes)
        {
            services.AddScoped(handlerGroup.InterfaceType, handlerGroup.ConcreteType);
        }
    }

    private static IEnumerable<HandlerTypeGrouper> GetHandlerTypes(params Type[] handlerTypes)
    {
        return Assembly.GetTypes()
            .Where(type => type is { IsClass: true, IsAbstract: false })
            .SelectMany(type => type.GetInterfaces()
                .Where(iface => iface.IsGenericType)
                .Select(iface => new InterfaceAndGenericGrouper(iface, iface.GetGenericTypeDefinition()))
                .Where(grouper => handlerTypes.Contains(grouper.GenericType))
                .Select(grouper => new HandlerTypeGrouper(grouper.InterfaceType, type)));
    }
}