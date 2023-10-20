using ProductionPlanner.Domain;

namespace ProductionPlanner.Application.Abstractions.Mappers;
public interface ICO2Mapper
{
    CO2Emission? Map(string name, decimal value);
}
