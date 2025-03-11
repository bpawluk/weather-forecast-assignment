using WeatherAssignment.Core.Exceptions;
using WeatherAssignment.Core.Values;

namespace WeatherAssignment.UnitTests.ValuesTests;

public class CoordinatesTests
{
    [Fact]
    public void Constructor_ValidCoordinates_ShouldSetProperties()
    {
        // Arrange
        decimal latitude = 45.1234m;
        decimal longitude = 90.5678m;

        // Act
        var coordinates = new Coordinates(latitude, longitude);

        // Assert
        Assert.Equal(Math.Round(latitude, 2), coordinates.Latitude);
        Assert.Equal(Math.Round(longitude, 2), coordinates.Longitude);
    }

    [Theory]
    [InlineData(-91)]
    [InlineData(91)]
    public void Constructor_InvalidLatitude_ShouldThrowValidationException(decimal latitude)
    {
        // Arrange
        decimal longitude = 0;

        // Act & Assert
        var exception = Assert.Throws<ValidationException>(() => new Coordinates(latitude, longitude));
        Assert.Equal($"Latitude must be between -90 and 90 degrees.", exception.Message);
    }

    [Theory]
    [InlineData(-181)]
    [InlineData(181)]
    public void Constructor_InvalidLongitude_ShouldThrowValidationException(decimal longitude)
    {
        // Arrange
        decimal latitude = 0;

        // Act & Assert
        var exception = Assert.Throws<ValidationException>(() => new Coordinates(latitude, longitude));
        Assert.Equal($"Longitude must be between -180 and 180 degrees.", exception.Message);
    }

    [Fact]
    public void ToString_ShouldReturnFormattedString()
    {
        // Arrange
        decimal latitude = 45.1234m;
        decimal longitude = 90.5678m;
        var coordinates = new Coordinates(latitude, longitude);

        // Act
        var result = coordinates.ToString();

        // Assert
        Assert.Equal("(45.12, 90.57)", result);
    }
}