using WeatherAssignment.Core.Exceptions;

namespace WeatherAssignment.Core.Values;

public record AtmosphericPressure
{
    public float Value { get; private set; }

    private AtmosphericPressure() { }

    public AtmosphericPressure(float value)
    {
        if (value < 0)
        {
            throw new ValidationException("Atmospheric Pressure cannot be negative.");
        }
        Value = value;
    }
}