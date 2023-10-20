namespace ProductionPlanner.Domain.Exceptions;
public class FuelNotAddedException : Exception
{
    public FuelNotAddedException(string? message) : base(message)
    {
    }
}
