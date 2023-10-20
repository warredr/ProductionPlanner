using ProductionPlanner.Application.Abstractions.Mappers;
using ProductionPlanner.Domain;
using ProductionPlanner.Domain.Fuels;

namespace ProductionPlanner.Application.Mappers;
internal class FuelMapper : IFuelMapper
{
    public Fuel? Map(string name, decimal value) => name.Split('(')[0].ToLower() switch
    {
        FuelType.Gas => new Gas(value),
        FuelType.Kerosine => new Kerosine(value),
        FuelType.Wind => new Wind(value),
        _ => null
    };
}