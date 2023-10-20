namespace ProductionPlanner.Domain.Exceptions;
public class FuelTypeNotCorrectException : Exception
{
    public FuelTypeNotCorrectException(string? message) : base(message)
    {
    }
}
