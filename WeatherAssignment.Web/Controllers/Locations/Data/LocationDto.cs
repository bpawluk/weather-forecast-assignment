namespace WeatherAssignment.Web.Controllers.Locations.Data;

public record LocationDto(
    string Name,
    decimal Latitude,
    decimal Longitude);