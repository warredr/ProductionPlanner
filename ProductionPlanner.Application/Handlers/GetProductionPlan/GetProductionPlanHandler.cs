using MediatR;
using Microsoft.Extensions.Logging;
using ProductionPlanner.Application.Abstractions;
using ProductionPlanner.Application.Abstractions.Mappers;
using ProductionPlanner.Application.Behavior;
using ProductionPlanner.Application.Exceptions;
using ProductionPlanner.Domain;
using ProductionPlanner.Domain.Fuels;
using ProductionPlanner.Domain.Powerplants;

namespace ProductionPlanner.Application.Queries.GetProductionPlan;
internal class GetProductionPlanHandler : IRequestHandler<GetProductionPlanRequest, ProductionPlan[]>
{
    private readonly ICO2Mapper _co2Mapper;
    private readonly IFuelMapper _fuelMapper;
    private readonly IPowerplantMapper _powerplantMapper;
    private readonly IProductionCalculator _productionCalculator;

    public GetProductionPlanHandler(
        ICO2Mapper co2Mapper,
        IFuelMapper fuelMapper,
        IPowerplantMapper powerplantMapper,
        IProductionCalculator productionCalculator)
    {
        _co2Mapper = co2Mapper;
        _fuelMapper = fuelMapper;
        _powerplantMapper = powerplantMapper;
        _productionCalculator = productionCalculator;
    }

    public async Task<ProductionPlan[]> Handle(GetProductionPlanRequest request, CancellationToken cancellationToken)
    {
        var fuels = GetAllProvidedFuels(request.Fuels);
        var co2Emission = GetCO2Emission(request.Fuels);
        var powerplants = GetAllPowerplants(request.Powerplants, fuels, co2Emission);

        return await Task.FromResult(_productionCalculator.CalculateProductionPlan(powerplants, request.Load));
    }

    private IEnumerable<Fuel?> GetAllProvidedFuels(IDictionary<string, decimal> providedFuels)
    {
        return providedFuels.Select(x => _fuelMapper.Map(x.Key, x.Value));
    }

    private CO2Emission? GetCO2Emission(IDictionary<string, decimal> providedFuels)
    {
        return providedFuels.Select(x => _co2Mapper.Map(x.Key, x.Value)).FirstOrDefault();
    }

    private IEnumerable<Powerplant> GetAllPowerplants(IEnumerable<PowerplantDto> providedPowerplants, IEnumerable<Fuel?> fuels, CO2Emission? cO2Emission)
    {
        var powerplants = new List<Powerplant>();
        foreach (var providedPowerplant in providedPowerplants)
        {
            var requiredFuelForPowerplant = PowerplantFuelHelper.GetFuelTypeForPowerplant(providedPowerplant.Type);
            var fuel = fuels.FirstOrDefault(x => x?.GetType().Name.Equals(requiredFuelForPowerplant, StringComparison.OrdinalIgnoreCase) == true);

            if (fuel == null)
            {
                throw new RequiredFuelForPowerplantNotFoundException($"name={providedPowerplant.Name} type={providedPowerplant.Type} | " +
                    $"fuel '{requiredFuelForPowerplant}' was not found");
            }

            var powerplant = _powerplantMapper.Map(providedPowerplant, fuel, cO2Emission);
            powerplants.Add(powerplant);
        }
        return powerplants;
    }
}
