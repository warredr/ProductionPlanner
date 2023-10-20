namespace ProductionPlanner.Domain.Fuels;
public sealed record Wind(decimal Percentage) : Fuel(PricePerMWh: 0);
