using WeatherAssignment.Core.Exceptions;
using WeatherAssignment.Core.Values;

namespace WeatherAssignment.UnitTests.ValuesTests;

public class ProbabilityTests
{
    [Fact]
    public void Constructor_ValidPercentage_SetsValue()
    {
        // Arrange
        int validPercentage = 50;

        // Act
        var probability = new Probability(validPercentage);

        // Assert
        Assert.Equal(validPercentage, probability.Value);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(101)]
    public void Constructor_InvalidPercentage_ThrowsValidationException(int invalidPercentage)
    {
        // Act & Assert
        Assert.Throws<ValidationException>(() => new Probability(invalidPercentage));
    }
}