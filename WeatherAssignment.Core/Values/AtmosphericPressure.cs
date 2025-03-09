namespace WeatherAssignment.Core.Values;

public record AtmosphericPressure
{
    public float Value { get; private set; }

    private AtmosphericPressure() { }

    public AtmosphericPressure(float value)
    {
        if (value < 0)
        {
            throw new Exception("Atmospheric Pressure cannot be negative.");
        }
        Value = value;
    }
}