namespace ProductionPlanner.Application.Exceptions;
public class PowerplantTypeNotFoundException : Exception
{
    public PowerplantTypeNotFoundException(string? message) : base(message)
    {
    }
}
