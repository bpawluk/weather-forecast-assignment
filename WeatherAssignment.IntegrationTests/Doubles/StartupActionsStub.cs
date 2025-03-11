using WeatherAssignment.Web.Utils;

namespace WeatherAssignment.IntegrationTests.Doubles;

internal class StartupActionsStub : IStartupActions
{
    public Task ExecuteAsync() => Task.CompletedTask;
}