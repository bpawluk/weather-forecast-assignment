using WeatherAssignment.Application.Queries.GetForecast;
using WeatherAssignment.Infrastructure.Extensions;
using WeatherAssignment.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure();

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(GetForecastQuery).Assembly);
});

builder.Services.AddOpenApi();
builder.Services.AddControllers();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    using var context = scope.ServiceProvider.GetRequiredService<WeatherDbContext>();
    await context.Database.EnsureCreatedAsync();
}

app.MapOpenApi();
app.UseSwaggerUI(options => 
{
    options.RoutePrefix = string.Empty;
    options.SwaggerEndpoint("/openapi/v1.json", "OpenAPI v1");
});

app.MapControllers();

app.Run();