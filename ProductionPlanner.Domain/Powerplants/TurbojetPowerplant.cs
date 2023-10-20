using ProductionPlanner.Domain.Fuels;

namespace ProductionPlanner.Domain.Powerplants;
public sealed class TurbojetPowerplant : Powerplant
{
    private TurbojetPowerplant(string name, decimal efficiency, decimal pMax, Kerosine kerosineFuel) 
        : base(name, efficiency, pMin: 0, pMax, kerosineFuel)
    {
    }

    public override string ExpectedFuelType => FuelType.Kerosine;

    /// <summary>
    /// Creates a new TurbojetPowerplant instance with the specified parameters.
    /// </summary>
    /// <param name="name">The name of the turbojet power plant.</param>
    /// <param name="efficiency">The efficiency of the power plant.</param>
    /// <param name="pMax">The maximum power output of the power plant.</param>
    /// <param name="kerosineFuel">The kerosene fuel used by the power plant.</param>
    /// <returns>A new TurbojetPowerplant instance.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the 'name' or 'kerosineFuel' parameter is null.</exception>
    public static TurbojetPowerplant? Create(string name,
        decimal efficiency, decimal pMax, Kerosine kerosineFuel)
    {
        if (name == null) throw new ArgumentNullException(nameof(name));
        if (kerosineFuel == null) throw new ArgumentNullException(nameof(kerosineFuel));

        return new TurbojetPowerplant(name, efficiency, pMax, kerosineFuel);
    }
}
