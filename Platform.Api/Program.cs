using Platform.Api.App;
using Platform.Api.Infrastructure;
using Platform.Api.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddRouting(opt => {
    opt.LowercaseUrls = true;
    opt.LowercaseQueryStrings = true;
});

builder.Services.AddInfrastructure();
builder.Services.AddApplication();

builder.Services.AddOpenApi();

builder.WebHost.UseUrls("http://0.0.0.0:80");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.SeedDatabase();

app.UseExceptionHandler(_ => { });

await app.RunAsync();