using System.Net.Http.Json;
using WeatherAssignment.Web.Controllers.Locations.Data;

namespace WeatherAssignment.IntegrationTests.LocationsTests;

public class GetLocationsTests(IntegrationTestsFixture fixture) : IntegrationTestsBase(fixture)
{
    [Fact]
    public async Task GetLocationsAsync_ShouldReturnOkWithLocations()
    {
        // Arrange
        var firstLocation = new LocationDto("Location 1", 10.0m, 20.0m);
        var secondLocation = new LocationDto("Location 2", 30.0m, 40.0m);
        await _fixture.ApiClient.PostAsJsonAsync("/Locations", firstLocation);
        await _fixture.ApiClient.PostAsJsonAsync("/Locations", secondLocation);

        // Act
        var locations = await _fixture.ApiClient.GetFromJsonAsync<LocationDto[]>("/Locations");

        // Assert
        Assert.NotNull(locations);
        Assert.Equal(2, locations.Length);
        Assert.Contains(locations, location => 
            location.Name == firstLocation.Name && 
            location.Latitude == firstLocation.Latitude && 
            location.Longitude == firstLocation.Longitude);
        Assert.Contains(locations, location =>
            location.Name == secondLocation.Name &&
            location.Latitude == secondLocation.Latitude &&
            location.Longitude == secondLocation.Longitude);
    }

    [Fact]
    public async Task GetLocationsAsync_WhenNoLocations_ShouldReturnOkWithEmptyArray()
    {
        // Act
        var locations = await _fixture.ApiClient.GetFromJsonAsync<LocationDto[]>("/Locations");

        // Assert
        Assert.NotNull(locations);
        Assert.Empty(locations);
    }
}