using Platform.Api.App.Core.Messaging;
using Platform.Api.App.Core.Messaging.Abstractions;
using Platform.Api.App.Core.Reflection;

namespace Platform.Api.App;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services)
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
        var assembly = typeof(DependencyInjection).Assembly;

        return assembly.GetTypes()
            .Where(type => type is { IsClass: true, IsAbstract: false })
            .SelectMany(type => type.GetInterfaces()
                .Where(iface => iface.IsGenericType)
                .Select(iface => new InterfaceAndGenericGrouper(iface, iface.GetGenericTypeDefinition()))
                .Where(grouper => handlerTypes.Contains(grouper.GenericType))
                .Select(grouper => new HandlerTypeGrouper(grouper.Interface, type)));
    }
}