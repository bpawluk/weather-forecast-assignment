namespace WeatherAssignment.Core;

public class Forecast
{
    private List<ForecastValue> _values = [];

    public int Id { get; private set; }

    public Location Location { get; private set; } = null!;

    public DateTimeOffset Updated { get; private set; }

    public IReadOnlyList<ForecastValue> Values => _values;

    private Forecast() { }

    public Forecast(Location location, DateTimeOffset updated, List<ForecastValue> values)
    {
        Location = location;
        Updated = updated;
        _values = values;
    }

    public static Forecast Empty(Location location) => new(location, DateTimeOffset.MinValue, []);

    public void Update(IReadOnlyList<ForecastValue> values)
    {
        _values.Clear();
        _values.AddRange(values);
        Updated = DateTimeOffset.UtcNow;
    }
}