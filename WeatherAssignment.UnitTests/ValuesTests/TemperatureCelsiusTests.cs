using WeatherAssignment.Core.Exceptions;
using WeatherAssignment.Core.Values;

namespace WeatherAssignment.UnitTests.ValuesTests;

public class TemperatureCelsiusTests
{
    [Fact]
    public void Constructor_ValidTemperature_ShouldSetTemperature()
    {
        // Arrange
        float validTemperature = 25.0f;

        // Act
        var temperature = new TemperatureCelsius(validTemperature);

        // Assert
        Assert.Equal(validTemperature, temperature.Value);
    }

    [Fact]
    public void Constructor_TemperatureBelowAbsoluteZero_ShouldThrowValidationException()
    {
        // Arrange
        float invalidTemperature = -274.0f;

        // Act & Assert
        Assert.Throws<ValidationException>(() => new TemperatureCelsius(invalidTemperature));
    }
}