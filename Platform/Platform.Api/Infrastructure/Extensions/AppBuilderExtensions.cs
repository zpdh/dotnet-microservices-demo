using Microsoft.EntityFrameworkCore;
using Platform.Api.Domain.Platform;
using Platform.Api.Infrastructure.Core;
using Platform.Api.Infrastructure.Core.Data;

namespace Platform.Api.Infrastructure.Extensions;

public static class AppBuilderExtensions
{
    public static void SeedDatabase(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();
        var context = serviceScope.ServiceProvider.GetService<AppDbContext>()!;

        context.Set<Domain.Platform.Platform>().AddRange(
            new Domain.Platform.Platform(".NET", "Microsoft"),
            new Domain.Platform.Platform("Java", "Oracle"),
            new Domain.Platform.Platform("JavaScript", "Oracle"),
            new Domain.Platform.Platform("Golang", "Google"));

        context.SaveChanges();
    }

    public static async Task ApplyMigrationsAsync(this IApplicationBuilder app)
    {
        await using var serviceScope = app.ApplicationServices.CreateAsyncScope();
        var context = serviceScope.ServiceProvider.GetService<AppDbContext>()!;
        await context.Database.MigrateAsync();
    }
}