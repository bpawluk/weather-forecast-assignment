using Moq;
using WeatherAssignment.Core.Interface;

namespace WeatherAssignment.IntegrationTests;

public sealed class IntegrationTestsFixture : IDisposable
{
    private readonly IntegrationTestsFactory _factory;

    public HttpClient ApiClient { get; }

    public IServiceProvider Services { get; }

    public Mock<IBackgroundMediator> BackgroundMediator { get; }

    public IntegrationTestsFixture() 
    {
        BackgroundMediator = new Mock<IBackgroundMediator>();
        _factory = new IntegrationTestsFactory(BackgroundMediator.Object);
        ApiClient = _factory.CreateClient();
        Services = _factory.Services;
    }

    public void Dispose()
    {
        ApiClient.Dispose();
        _factory.Dispose();
    }
}