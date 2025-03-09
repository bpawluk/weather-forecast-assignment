using WeatherAssignment.Core.Values;

namespace WeatherAssignment.Core;

public class Location
{
    public int Id { get; private set; }

    public string Name { get; private set; } = null!;

    public Coordinates Coordinates { get; private set; } = null!;

    private Location() { }

    public Location(string name, decimal latitude, decimal longitude)
    {
        Name = name;
        Coordinates = new Coordinates(latitude, longitude);
    }
}