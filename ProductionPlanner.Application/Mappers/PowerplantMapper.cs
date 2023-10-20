using ProductionPlanner.Application.Abstractions.Mappers;
using ProductionPlanner.Application.Behavior;
using ProductionPlanner.Application.Exceptions;
using ProductionPlanner.Application.Queries.GetProductionPlan;
using ProductionPlanner.Domain;
using ProductionPlanner.Domain.Fuels;
using ProductionPlanner.Domain.Powerplants;

namespace ProductionPlanner.Application.Mappers;
internal class PowerplantMapper : IPowerplantMapper
{
    public Powerplant Map(PowerplantDto powerplantDto, Fuel fuel, CO2Emission? cO2Emission = null)
    {
        if (powerplantDto == null) throw new ArgumentNullException(nameof(powerplantDto));

        switch (powerplantDto.Type) 
        {
            case PowerplantType.GasFired when fuel is Gas gasFuel:
                return GasFiredPowerplant.Create(powerplantDto.Name, powerplantDto.Efficiency, powerplantDto.Pmin, powerplantDto.Pmax, gasFuel);

            case PowerplantType.TurboJet when fuel is Kerosine kerosineFuel:
                return TurbojetPowerplant.Create(powerplantDto.Name, powerplantDto.Efficiency, powerplantDto.Pmax, kerosineFuel);

            case PowerplantType.WindTurbine when fuel is Wind windFuel:
                return WindTurbinePowerplant.Create(powerplantDto.Name, powerplantDto.Efficiency, powerplantDto.Pmax, windFuel);

            default:
                throw new PowerplantTypeNotFoundException($"Powerplant type '{powerplantDto.Type}' with name '{powerplantDto.Name}' was not found.");
        }
    }
}
