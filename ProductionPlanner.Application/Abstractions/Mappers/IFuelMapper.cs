using ProductionPlanner.Domain.Fuels;

namespace ProductionPlanner.Application.Abstractions.Mappers;
public interface IFuelMapper
{
    Fuel? Map(string name, decimal value);
}
