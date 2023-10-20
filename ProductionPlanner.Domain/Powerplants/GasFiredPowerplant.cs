using ProductionPlanner.Domain.Exceptions;
using ProductionPlanner.Domain.Fuels;

namespace ProductionPlanner.Domain.Powerplants;
public sealed class GasFiredPowerplant : Powerplant
{
    private readonly CO2Emission? _co2Emission;

    private GasFiredPowerplant(string name, decimal efficiency, decimal pMin, decimal pMax, Gas gasFuel, CO2Emission? co2Emission = null)
        : base(name, efficiency, pMin, pMax, gasFuel)
    {
        _co2Emission = co2Emission;
    }

    public override string ExpectedFuelType => FuelType.Gas;

    /// <summary>
    /// Creates a new GasFiredPowerplant instance with the specified parameters.
    /// </summary>
    /// <param name="name">The name of the power plant.</param>
    /// <param name="efficiency">The efficiency of the power plant.</param>
    /// <param name="pMin">The minimum power output of the power plant.</param>
    /// <param name="pMax">The maximum power output of the power plant.</param>
    /// <param name="gasFuel">The gas fuel used by the power plant.</param>
    /// <param name="co2Emission">The CO2 emissions (optional).</param>
    /// <returns>A new GasFiredPowerplant instance.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the 'name' or 'gasFuel' parameter is null.</exception>
    public static GasFiredPowerplant? Create(string name, decimal efficiency, decimal pMin, decimal pMax, Gas gasFuel, CO2Emission? co2Emission = null)
    {
        if (name is null) throw new ArgumentNullException(nameof(name));
        if (gasFuel is null) throw new ArgumentNullException(nameof(gasFuel));

        return new GasFiredPowerplant(name, efficiency, pMin, pMax, gasFuel, co2Emission);
    }

    public override decimal TotalPrice()
    {
        ValidateIfFuelIsPresent();

        if (_fuel is Gas)
        {
            if (_co2Emission != null)
            {
                var totalPotentialCO2OutputInTons = CO2Emission.CO2OutputInTonsPerMWh * PMax;
                var co2Price = _co2Emission.PricePerTonCO2 * totalPotentialCO2OutputInTons;
                return base.TotalPrice() + co2Price;
            }

            return base.TotalPrice();
        }

        throw new FuelTypeNotCorrectException($"GasFiredPowerplant | the provided fuel or CO2 emission is not correct");
    }
}
