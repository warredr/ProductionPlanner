using ProductionPlanner.Application.Queries.GetProductionPlan;
using ProductionPlanner.Domain.Powerplants;

namespace ProductionPlanner.Application.Abstractions;
public interface IProductionCalculator
{
    ProductionPlan[] CalculateProductionPlan(IEnumerable<Powerplant> powerplants, decimal requestedLoad);
}
