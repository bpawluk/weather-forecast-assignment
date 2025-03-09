using WeatherAssignment.Core.Values;

namespace WeatherAssignment.Core;

public class ForecastValue(DateTimeOffset time, float temperature, int precipitation, float pressure)
{
    public int Id { get; private set; }

    public DateTimeOffset Time { get; private set; } = time;

    public TemperatureCelsius Temperature { get; private set; } = new(temperature);

    public Probability Precipitation { get; private set; } = new(precipitation);

    public AtmosphericPressure Pressure { get; private set; } = new(pressure);
}