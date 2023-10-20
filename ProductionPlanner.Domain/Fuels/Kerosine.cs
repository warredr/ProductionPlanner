namespace ProductionPlanner.Domain.Fuels;
public sealed record Kerosine(decimal PricePerMWh) : Fuel(PricePerMWh);