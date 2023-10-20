using Microsoft.Extensions.DependencyInjection;
using ProductionPlanner.Application.Abstractions;
using ProductionPlanner.Application.Abstractions.Mappers;
using ProductionPlanner.Application.Mappers;
using ProductionPlanner.Application.Queries.GetProductionPlan;

namespace ProductionPlanner.Application.IOC;
public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IFuelMapper, FuelMapper>();
        services.AddScoped<ICO2Mapper, CO2Mapper>();
        services.AddScoped<IPowerplantMapper, PowerplantMapper>();
        services.AddScoped<IProductionCalculator, ProductionCalculator>();

        return services;
    }
}
