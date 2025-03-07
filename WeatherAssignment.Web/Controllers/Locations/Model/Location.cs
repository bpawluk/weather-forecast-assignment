using System.ComponentModel.DataAnnotations;

namespace WeatherAssignment.Web.Controllers.Locations.Model;

public record Location
{
    public string Name { get; init; } = string.Empty;

    public decimal Latitude { get; init; }

    public decimal Longitude { get; init; }
}