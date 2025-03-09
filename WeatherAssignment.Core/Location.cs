using WeatherAssignment.Core.Values;

namespace WeatherAssignment.Core;

public class Location(string name, decimal latitude, decimal longitude)
{
    public int Id { get; private set; }

    public string Name { get; private set; } = name;

    public Coordinates Coordinates { get; private set; } = new(latitude, longitude);
}