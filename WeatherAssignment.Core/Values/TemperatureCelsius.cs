namespace WeatherAssignment.Core.Values;

public readonly struct TemperatureCelsius
{
    public float Value { get; }

    public TemperatureCelsius(float value)
    {
        if (value < -273.15)
        {
            throw new Exception("Temperature cannot be below absolute zero (-273.15°C).");
        }
        Value = value;
    }
}