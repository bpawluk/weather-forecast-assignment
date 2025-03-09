namespace WeatherAssignment.Core.Values;

public readonly struct Probability
{
    public int Value { get; }

    public Probability(int percentage)
    {
        if (percentage < 0 || percentage > 100)
        {
            throw new Exception("Probability must be between 0 and 100 percent.");
        }
        Value = percentage;
    }
}