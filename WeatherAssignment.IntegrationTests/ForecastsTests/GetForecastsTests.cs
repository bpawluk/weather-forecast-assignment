using System.Globalization;
using System.Net;
using System.Net.Http.Json;
using WeatherAssignment.Web.Controllers.Forecasts.Data;
using WeatherAssignment.Web.Controllers.Locations.Data;

namespace WeatherAssignment.IntegrationTests.ForecastsTests;

public class GetForecastsTests(IntegrationTestsFixture fixture) : IntegrationTestsBase(fixture)
{
    [Fact]
    public async Task GetForecastAsync_ForExistingLocation_ShouldReturnOkWithForecast()
    {
        // Arrange
        var location = new LocationDto("Test Location", 10.0m, 20.0m);
        await _fixture.ApiClient.PostAsJsonAsync("/Locations", location);

        // Act
        var result = await _fixture.ApiClient.GetFromJsonAsync<ForecastDto>($"/Forecasts" +
            $"?latitude={location.Latitude.ToString(CultureInfo.InvariantCulture)}" +
            $"&longitude={location.Longitude.ToString(CultureInfo.InvariantCulture)}");

        // Assert
        Assert.NotNull(result);
        Assert.Equal(DateTimeOffset.MinValue, result.Updated);
        Assert.Empty(result.Values);
    }

    [Fact]
    public async Task GetForecastAsync_ForNonExistingLocation_ShouldReturnNotFound()
    {
        // Act
        var response = await _fixture.ApiClient.GetAsync("/Forecasts?latitude=10.0&longitude=20.0");

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Theory]
    [InlineData(-91, 0)]
    [InlineData(91, 0)]
    [InlineData(0, -181)]
    [InlineData(0, 181)]
    public async Task GetForecastAsync_ForInvalidCoordinates_ShouldReturnBadRequest(decimal latitude, decimal longitude)
    {
        // Act
        var response = await _fixture.ApiClient.GetAsync($"/Forecasts" +
            $"?latitude={latitude.ToString(CultureInfo.InvariantCulture)}" +
            $"&longitude={longitude.ToString(CultureInfo.InvariantCulture)}");

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}