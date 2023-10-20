using MediatR;

namespace ProductionPlanner.Application.Queries.GetProductionPlan;
public class GetProductionPlanRequest : IRequest<ProductionPlan[]>
{
    public decimal Load { get; init; }
    public IDictionary<string, decimal> Fuels { get; init; } = new Dictionary<string, decimal>();
    public IEnumerable<PowerplantDto> Powerplants { get; init; } = new List<PowerplantDto>();
}

public class PowerplantDto
{
    public string Name { get; init; } = string.Empty;
    public string Type { get; init; } = string.Empty;
    public decimal Efficiency { get; init; }
    public decimal Pmin { get; init; }
    public decimal Pmax { get; init; }
}