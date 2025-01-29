using Api.App.Core.Messaging;
using Api.App.Core.Reflection;

namespace Api.App;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddCommands();
        services.AddQueries();
    }

    private static void AddCommands(this IServiceCollection services)
    {
        var commandHandlerTypes = GetHandlerTypes(typeof(ICommandHandler<>), typeof(ICommandHandler<,>));

        foreach (var handlerGroup in commandHandlerTypes)
        {
            services.AddTransient(handlerGroup.InterfaceType, handlerGroup.ConcreteType);
        }
    }

    private static void AddQueries(this IServiceCollection services)
    {
        var handlerTypes = GetHandlerTypes(typeof(IQueryHandler<,>));

        foreach (var handlerGroup in handlerTypes)
        {
            services.AddTransient(handlerGroup.InterfaceType, handlerGroup.ConcreteType);
        }
    }


    private static IEnumerable<HandlerTypeGrouper> GetHandlerTypes(Type handlerType, Type? secondHandlerType = null)
    {
        var assembly = typeof(DependencyInjection).Assembly;

        return assembly.GetTypes()
            .Where(type => type is { IsClass: true, IsAbstract: false })
            .SelectMany(type => type.GetInterfaces()
                .Where(iface => iface.IsGenericType)
                .Select(iface => new InterfaceAndGenericGrouper(iface, iface.GetGenericTypeDefinition()))
                .Where(grouper => {
                    var condition = grouper.GenericType == handlerType;

                    if (secondHandlerType is not null)
                    {
                        condition = grouper.GenericType == handlerType || grouper.GenericType == secondHandlerType;
                    }

                    return condition;
                })
                .Select(grouper => new HandlerTypeGrouper(grouper.Interface, type)));
    }
}