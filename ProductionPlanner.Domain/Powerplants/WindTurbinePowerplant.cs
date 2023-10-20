using ProductionPlanner.Domain.Fuels;

namespace ProductionPlanner.Domain.Powerplants;
public class WindTurbinePowerplant : Powerplant
{
    private WindTurbinePowerplant(string name, decimal efficiency, decimal pMax, Wind windFuel)
        : base(name, efficiency, pMin: 0, pMax, windFuel)
    {
    }

    public override string ExpectedFuelType => FuelType.Wind;

    /// <summary>
    /// Creates a new WindTurbinePowerplant instance with the specified parameters.
    /// </summary>
    /// <param name="name">The name of the windturbine power plant.</param>
    /// <param name="efficiency">The efficiency of the power plant.</param>
    /// <param name="pMax">The maximum power output of the power plant.</param>
    /// <param name="windFuel">The percentage of wind available to be used by the power plant.</param>
    /// <returns>A new WindTurbinePowerplant instance.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the 'name' or 'windFuel' parameter is null.</exception>
    public static WindTurbinePowerplant? Create(string name,
        decimal efficiency, decimal pMax, Wind windFuel)
    {
        if (name == null) throw new ArgumentNullException(nameof(name));
        if (windFuel == null) throw new ArgumentNullException(nameof(windFuel));

        return new WindTurbinePowerplant(name, efficiency, pMax, windFuel);
    }
}
