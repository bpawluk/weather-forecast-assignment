namespace WeatherAssignment.Core;

public class Forecast(int locationId, DateTimeOffset updated, IReadOnlyList<ForecastValue> values)
{
    public int Id { get; private set; }

    public int LocationId { get; private set; } = locationId;

    public DateTimeOffset Updated { get; private set; } = updated;

    public IReadOnlyList<ForecastValue> Values { get; private set; } = values;
}