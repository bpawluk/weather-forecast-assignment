namespace WeatherAssignment.Core;

public class Forecast
{
    public int Id { get; private set; }

    public Location Location { get; private set; } = null!;

    public DateTimeOffset Updated { get; private set; }

    public IReadOnlyList<ForecastValue> Values { get; private set; } = [];

    private Forecast() { }

    public Forecast(Location location, DateTimeOffset updated, IReadOnlyList<ForecastValue> values)
    {
        Location = location;
        Updated = updated;
        Values = values;
    }

    public static Forecast Empty(Location location) => new(location, DateTimeOffset.MinValue, []);
}