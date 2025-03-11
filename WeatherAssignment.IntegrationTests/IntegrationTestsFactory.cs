using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using WeatherAssignment.Core.Interface;
using WeatherAssignment.IntegrationTests.Doubles;
using WeatherAssignment.Web.Utils;

namespace WeatherAssignment.IntegrationTests;

internal class IntegrationTestsFactory(IBackgroundMediator backgroundMediator) : WebApplicationFactory<Program>
{
    private readonly IBackgroundMediator _backgroundMediator = backgroundMediator;

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            services.AddSingleton(_backgroundMediator);
            services.AddSingleton<IStartupActions, StartupActionsStub>();
        });
    }
}