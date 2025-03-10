namespace WeatherAssignment.Core.Exceptions;

public class EntityAlreadyExistsException : Exception
{
    public EntityAlreadyExistsException() : base("Entity already exists.")
    {
    }

    public EntityAlreadyExistsException(string message) : base(message)
    {
    }

    public EntityAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
    {
    }
}