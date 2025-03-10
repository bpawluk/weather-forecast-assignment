using WeatherAssignment.Application.Queries.GetForecast;
using WeatherAssignment.Infrastructure.Extensions;
using WeatherAssignment.Web.Utils;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure();
builder.Services.AddScoped<IStartupActions, StartupActions>();

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(GetForecastQuery).Assembly);
});

builder.Services.AddOpenApi();
builder.Services.AddControllers();

var app = builder.Build();

app.MapOpenApi();
app.UseSwaggerUI(options =>
{
    options.RoutePrefix = string.Empty;
    options.SwaggerEndpoint("/openapi/v1.json", "OpenAPI v1");
});

app.MapControllers();

using var scope = app.Services.CreateScope();
var startupActions = scope.ServiceProvider.GetRequiredService<IStartupActions>();
await startupActions.ExecuteAsync();

app.Run();