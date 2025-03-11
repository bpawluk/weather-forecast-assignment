using Hangfire;
using WeatherAssignment.Application.Extensions;
using WeatherAssignment.Infrastructure.Extensions;
using WeatherAssignment.Web.Middleware;
using WeatherAssignment.Web.Utils;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services.AddScoped<IStartupActions, StartupActions>();

builder.Services.AddOpenApi();
builder.Services.AddProblemDetails();
builder.Services.AddControllers();

var app = builder.Build();

app.MapOpenApi();
app.UseSwaggerUI(options =>
{
    options.RoutePrefix = string.Empty;
    options.SwaggerEndpoint("/openapi/v1.json", "OpenAPI v1");
});

app.MapHangfireDashboard(new DashboardOptions()
{
    Authorization = []
});

app.UseMiddleware<CustomExceptionHandlingMiddleware>();
app.MapControllers();

using var scope = app.Services.CreateScope();
var startupActions = scope.ServiceProvider.GetRequiredService<IStartupActions>();
await startupActions.ExecuteAsync();

app.Run();