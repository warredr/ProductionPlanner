using System.Text.Json.Serialization;

namespace ProductionPlanner.Application.Queries.GetProductionPlan;
public class ProductionPlan
{
    [JsonPropertyName("name")]
    public string Name { get; init; } = string.Empty;

    [JsonPropertyName("p")]
    public decimal ToBeProduced { get; init; }
}
