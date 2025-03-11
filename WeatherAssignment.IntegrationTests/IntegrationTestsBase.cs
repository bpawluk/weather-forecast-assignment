using Microsoft.Extensions.DependencyInjection;
using WeatherAssignment.Infrastructure.Persistence;

namespace WeatherAssignment.IntegrationTests;

[Collection(nameof(IntegrationTestsCollection))]
public class IntegrationTestsBase(IntegrationTestsFixture fixture) : IAsyncLifetime
{
    protected readonly IntegrationTestsFixture _fixture = fixture;

    public async Task InitializeAsync()
    {
        using var scope = _fixture.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<WeatherDbContext>();
        await dbContext.Database.EnsureDeletedAsync();
        await dbContext.Database.EnsureCreatedAsync();
    }

    public Task DisposeAsync() => Task.CompletedTask;
}