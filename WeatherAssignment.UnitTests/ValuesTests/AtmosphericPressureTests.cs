using WeatherAssignment.Core.Exceptions;
using WeatherAssignment.Core.Values;

namespace WeatherAssignment.UnitTests.ValuesTests;

public class AtmosphericPressureTests
{
    [Fact]
    public void Constructor_ShouldSetValidValue()
    {
        // Arrange
        float validValue = 1013.25f;

        // Act
        var pressure = new AtmosphericPressure(validValue);

        // Assert
        Assert.Equal(validValue, pressure.Value);
    }

    [Fact]
    public void Constructor_ShouldThrowValidationException_ForNegativeValue()
    {
        // Arrange
        float invalidValue = -1f;

        // Act & Assert
        Assert.Throws<ValidationException>(() => new AtmosphericPressure(invalidValue));
    }
}