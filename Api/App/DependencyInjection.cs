using Api.App.Core.Messaging;
using Api.App.Core.Messaging.Abstractions;
using Api.App.Core.Reflection;

namespace Api.App;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddCommands();
        services.AddQueries();
    }

    private static void AddMediator(this IServiceCollection services)
    {
        services.AddScoped<IMediator, Mediator>();
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
        /* It's common for this to be confusing, so I'll break it down for myself and other readers:
         * First, gets the assembly of this file.
         * Then, gets all the types inside of it, then filters by types that are classes and aren't abstract.
         * After that, gets the interfaces associated with the non-abstract type, the interfaces it implements.
         * Upon completion, checks if the interface in question contains generic types,
         * if it does, it creates a grouper record containing the interface and the generic type.
         * Once done, filters the groupers by a specified condition,
         * condition being that the generic type is a handler type (ICommandHandler or IQueryHandler, with one or multiple parameters).
         * And to top it all off, it creates another grouper, containing the interface and the class that implements the interface.
         * This interface will be a handler interface, and this class will be a handler implementation.
         * I'd like to mention that the method accepts up to two handler types, for cases where there are multiple interfaces with different parameter counts.
         * For example, ICommandHandler has 2 interfaces associated with it, one with a parameter count of 1, and another with a parameter count of 2.
         */
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