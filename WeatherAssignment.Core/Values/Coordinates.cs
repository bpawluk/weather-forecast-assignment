namespace WeatherAssignment.Core.Values;

public record Coordinates
{
    private const int Precision = 2;

    private const decimal MinLatitude = -90m;
    private const decimal MaxLatitude = 90m;
    private const decimal MinLongitude = -180m;
    private const decimal MaxLongitude = 180m;

    public decimal Latitude { get; private set; }

    public decimal Longitude { get; private set; }

    private Coordinates() { }

    public Coordinates(decimal latitude, decimal longitude)
    {
        if (latitude < MinLatitude || latitude > MaxLatitude)
        {
            throw new Exception($"Latitude must be between {MinLatitude} and {MaxLatitude} degrees.");
        }

        if (longitude < MinLongitude || longitude > MaxLongitude)
        {
            throw new Exception($"Longitude must be between {MinLongitude} and {MaxLongitude} degrees.");
        }

        Latitude = Math.Round(latitude, Precision);
        Longitude = Math.Round(longitude, Precision);
    }

    public override string ToString() => $"({Latitude}, {Longitude})";
}
