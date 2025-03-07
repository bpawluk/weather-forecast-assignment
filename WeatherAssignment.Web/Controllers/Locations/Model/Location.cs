namespace WeatherAssignment.Web.Controllers.Locations.Model;

public record Location(
    string Name, 
    decimal Latitude, 
    decimal Longitude);