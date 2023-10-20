using ProductionPlanner.Application.Exceptions;
using ProductionPlanner.Domain;

namespace ProductionPlanner.Application.Behavior;
internal static class PowerplantFuelHelper
{
    public static string GetFuelTypeForPowerplant(string powerplantType) => powerplantType switch
    {
        PowerplantType.GasFired => FuelType.Gas,
        PowerplantType.TurboJet => FuelType.Kerosine,
        PowerplantType.WindTurbine => FuelType.Wind,
        _ => throw new PowerplantTypeNotFoundException($"Powerplant type '{powerplantType}' was not found.")
    };
}
