namespace WeatherAssignment.Web.Controllers.Forecasts.Model;

public record Forecast(
    DateTimeOffset Updated, 
    Forecast.Value[] Values)
{
    public record Value(
        DateTimeOffset Time, 
        float Temperature, 
        float Precipitation, 
        float Pressure);
}