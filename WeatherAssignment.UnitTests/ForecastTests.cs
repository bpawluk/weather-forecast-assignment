using WeatherAssignment.Core;

namespace WeatherAssignment.UnitTests;

public class ForecastTests
{
    [Fact]
    public void Constructor_ShouldInitializeProperties()
    {
        // Arrange
        var location = new Location("TestLocation", 10.0m, 20.0m);
        var updated = DateTimeOffset.UtcNow;
        var values = new List<ForecastValue>
        {
            new(DateTimeOffset.UtcNow, 25.0f, 50, 1013.25f)
        };

        // Act
        var forecast = new Forecast(location, updated, values);

        // Assert
        Assert.Equal(default, forecast.Id);
        Assert.Equal(location, forecast.Location);
        Assert.Equal(updated, forecast.Updated);
        Assert.Equal(values, forecast.Values);
    }

    [Fact]
    public void Empty_ShouldReturnForecastWithMinValueUpdated()
    {
        // Arrange
        var location = new Location("TestLocation", 10.0m, 20.0m);

        // Act
        var forecast = Forecast.Empty(location);

        // Assert
        Assert.Equal(default, forecast.Id);
        Assert.Equal(location, forecast.Location);
        Assert.Equal(DateTimeOffset.MinValue, forecast.Updated);
        Assert.Empty(forecast.Values);
    }

    [Fact]
    public void Update_ShouldUpdateValuesAndSetUpdatedToNow()
    {
        // Arrange
        var location = new Location("TestLocation", 10.0m, 20.0m);
        var forecast = new Forecast(location, DateTimeOffset.UtcNow.AddDays(-1), []);
        var newValues = new List<ForecastValue>
        {
            new(DateTimeOffset.UtcNow, 30.0f, 60, 1015.0f)
        };

        // Act
        forecast.Update(newValues);

        // Assert
        Assert.Equal(newValues, forecast.Values);
        Assert.True((DateTimeOffset.UtcNow - forecast.Updated).TotalSeconds < 1);
    }
}