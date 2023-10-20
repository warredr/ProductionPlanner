using ProductionPlanner.Application.Queries.GetProductionPlan;
using ProductionPlanner.Domain;
using ProductionPlanner.Domain.Fuels;
using ProductionPlanner.Domain.Powerplants;

namespace ProductionPlanner.Application.Abstractions.Mappers;
public interface IPowerplantMapper
{
    Powerplant Map(PowerplantDto powerplantDto, Fuel fuel, CO2Emission? cO2Emission = null);
}
