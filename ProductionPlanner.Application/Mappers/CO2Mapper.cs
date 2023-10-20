using ProductionPlanner.Application.Abstractions.Mappers;
using ProductionPlanner.Domain;

namespace ProductionPlanner.Application.Mappers;
internal class CO2Mapper : ICO2Mapper
{
    private const string co2 = "co2";

    public CO2Emission? Map(string name, decimal value)
    {
        if (name.ToLower().StartsWith(co2))
        {
            return new CO2Emission(value);
        }

        return null;
    }
}
