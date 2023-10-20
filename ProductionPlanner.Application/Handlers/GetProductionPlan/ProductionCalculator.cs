using ProductionPlanner.Application.Abstractions;
using ProductionPlanner.Domain.Powerplants;

namespace ProductionPlanner.Application.Queries.GetProductionPlan;
internal class ProductionCalculator : IProductionCalculator
{
    public ProductionPlan[] CalculateProductionPlan(IEnumerable<Powerplant> powerplants, decimal requestedLoad)
    {
        var powerplantsCheapToExpensive = powerplants.OrderBy(x => x.TotalPrice());

        var leftoverLoad = requestedLoad;
        var powerplantsToUse = new List<ProductionPlan>();
        foreach (var powerplant in powerplantsCheapToExpensive)
        {
            if (leftoverLoad == 0) break;

            if (powerplant.CanProvideEnergy(leftoverLoad))
            {
                var toBeProduced = powerplant.PMax - leftoverLoad < 0
                    ? powerplant.PMax
                    : powerplant.PMax - leftoverLoad;

                leftoverLoad -= toBeProduced;

                powerplantsToUse.Add(new() { Name = powerplant.Name, ToBeProduced = toBeProduced });
            }
            else
            {
                powerplantsToUse.Add(new() { Name = powerplant.Name, ToBeProduced = 0 });
            }
        }

        var notYetCheckedPowerplants = powerplantsCheapToExpensive
            .Where(x => !powerplantsToUse.Any(y => y.Name == x.Name))
            .Select(x => new ProductionPlan { Name = x.Name });

        powerplantsToUse.AddRange(notYetCheckedPowerplants);

        return powerplantsToUse.ToArray();
    }
}
