namespace WeatherAssignment.Core.Values;

public readonly struct AtmosphericPressure
{
    public float Value { get; }

    public AtmosphericPressure(float value)
    {
        if (value < 0)
        {
            throw new Exception("Atmospheric Pressure cannot be negative.");
        }
        Value = value;
    }
}