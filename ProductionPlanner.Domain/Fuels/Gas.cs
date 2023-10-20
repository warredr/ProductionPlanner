namespace ProductionPlanner.Domain.Fuels;
public sealed record Gas(decimal PricePerMWh) : Fuel(PricePerMWh);