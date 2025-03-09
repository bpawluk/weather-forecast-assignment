using WeatherAssignment.Core.Values;

namespace WeatherAssignment.Core;

public class ForecastValue
{
    public int Id { get; private set; }

    public DateTimeOffset Time { get; private set; }

    public TemperatureCelsius Temperature { get; private set; } = null!;

    public Probability Precipitation { get; private set; } = null!;

    public AtmosphericPressure Pressure { get; private set; } = null!;

    private ForecastValue() { }

    public ForecastValue(DateTimeOffset time, float temperature, int precipitation, float pressure)
    {
        Time = time;
        Temperature = new(temperature);
        Precipitation = new(precipitation);
        Pressure = new(pressure);
    }
}