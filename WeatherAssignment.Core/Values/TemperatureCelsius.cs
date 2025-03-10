using WeatherAssignment.Core.Exceptions;

namespace WeatherAssignment.Core.Values;

public record TemperatureCelsius
{
    public float Value { get; private set; }

    private TemperatureCelsius() { }

    public TemperatureCelsius(float value)
    {
        if (value < -273.15)
        {
            throw new ValidationException("Temperature cannot be below absolute zero (-273.15°C).");
        }
        Value = value;
    }
}