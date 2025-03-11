using System.Net;
using System.Net.Http.Json;
using Moq;
using WeatherAssignment.Application.Commands.UpdateForecasts;
using WeatherAssignment.Web.Controllers.Locations.Data;

namespace WeatherAssignment.IntegrationTests.LocationsTests;

public class AddLocationTests(IntegrationTestsFixture fixture) : IntegrationTestsBase(fixture)
{
    [Fact]
    public async Task AddLocationAsync_ForNewLocation_ShouldReturnCreated()
    {
        // Arrange
        var newLocation = new LocationDto("Test Location", 50.0m, 50.0m);

        // Act
        var response = await _fixture.ApiClient.PostAsJsonAsync("/Locations", newLocation);

        // Assert
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        _fixture.BackgroundMediator.Verify(mediator => mediator.Enqueue(It.Is<UpdateForecastsCommand>(command =>
            command.LocationsCoordinates.Count == 1 &&
            command.LocationsCoordinates.Any(location => 
                location.Latitude == newLocation.Latitude && 
                location.Longitude == newLocation.Longitude))), 
            Times.Once);
    }

    [Fact]
    public async Task AddLocationAsync_ForExistingLocation_ShouldReturnConflict()
    {
        // Arrange
        var newLocation = new LocationDto("Test Location", 10.0m, 20.0m);

        // Act
        await _fixture.ApiClient.PostAsJsonAsync("/Locations", newLocation);
        var response = await _fixture.ApiClient.PostAsJsonAsync("/Locations", newLocation);

        // Assert
        Assert.Equal(HttpStatusCode.Conflict, response.StatusCode);
    }

    [Theory]
    [InlineData(-91, 0)]
    [InlineData(91, 0)]
    [InlineData(0, -181)]
    [InlineData(0, 181)]
    public async Task AddLocationAsync_ForInvalidCoordinates_ShouldReturnBadRequest(decimal latitude, decimal longitude)
    {
        // Arrange
        var newLocation = new LocationDto("Invalid Location", latitude, longitude);

        // Act
        var response = await _fixture.ApiClient.PostAsJsonAsync("/Locations", newLocation);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}