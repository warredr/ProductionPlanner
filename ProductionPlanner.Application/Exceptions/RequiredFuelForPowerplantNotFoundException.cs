namespace ProductionPlanner.Application.Exceptions;
public class RequiredFuelForPowerplantNotFoundException : Exception
{
    public RequiredFuelForPowerplantNotFoundException(string? message) : base(message)
    {
    }
}
