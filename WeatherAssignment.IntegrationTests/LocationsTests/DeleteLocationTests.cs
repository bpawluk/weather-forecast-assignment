using System.Globalization;
using System.Net;
using System.Net.Http.Json;
using WeatherAssignment.Web.Controllers.Locations.Data;

namespace WeatherAssignment.IntegrationTests.LocationsTests;

public class DeleteLocationTests(IntegrationTestsFixture fixture) : IntegrationTestsBase(fixture)
{
    [Fact]
    public async Task DeleteLocationAsync_ForExistingLocation_ShouldReturnNoContent()
    {
        // Arrange
        var latitude = 10.0m;
        var longitude = 20.0m;
        var location = new LocationDto("Test Location", latitude, longitude);
        await _fixture.ApiClient.PostAsJsonAsync("/Locations", location);

        // Act
        var response = await _fixture.ApiClient.DeleteAsync($"/Locations" +
            $"?latitude={latitude.ToString(CultureInfo.InvariantCulture)}" +
            $"&longitude={longitude.ToString(CultureInfo.InvariantCulture)}");

        // Assert
        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
    }

    [Fact]
    public async Task DeleteLocationAsync_ForNonExistingLocation_ShouldReturnNotFound()
    {
        // Arrange
        var latitude = 10.0m;
        var longitude = 20.0m;

        // Act
        var response = await _fixture.ApiClient.DeleteAsync($"/Locations" +
            $"?latitude={latitude.ToString(CultureInfo.InvariantCulture)}" +
            $"&longitude={longitude.ToString(CultureInfo.InvariantCulture)}");

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Theory]
    [InlineData(-91, 0)]
    [InlineData(91, 0)]
    [InlineData(0, -181)]
    [InlineData(0, 181)]
    public async Task DeleteLocationAsync_ForInvalidCoordinates_ShouldReturnBadRequest(decimal latitude, decimal longitude)
    {
        // Act
        var response = await _fixture.ApiClient.DeleteAsync($"/Locations" +
            $"?latitude={latitude.ToString(CultureInfo.InvariantCulture)}" +
            $"&longitude={longitude.ToString(CultureInfo.InvariantCulture)}");

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}