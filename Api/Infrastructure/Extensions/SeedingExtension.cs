using Api.Domain.Platform;
using Api.Infrastructure.Core;
using Api.Infrastructure.Core.Data;

namespace Api.Infrastructure.Extensions;

public static class SeedingExtension
{
    public static void SeedDatabase(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();
        var context = serviceScope.ServiceProvider.GetService<AppDbContext>()!;

        context.Set<Platform>().AddRange(
            new Platform(".NET", "Microsoft"),
            new Platform("Java", "Oracle"),
            new Platform("JavaScript", "Oracle"),
            new Platform("Golang", "Google"));

        context.SaveChanges();
    }
}