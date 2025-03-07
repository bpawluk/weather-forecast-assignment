namespace WeatherAssignment.Web.Controllers.Forecasts.Model;

public record Forecast
{
    public DateTimeOffset Updated { get; init; }

    public ForecastValue[] Values { get; init; } = [];

    public record ForecastValue
    {
        public DateTimeOffset Time { get; init; }

        public float Temperature { get; init; }

        public float Precipitation { get; init; }

        public float Pressure { get; init; }
    }
}