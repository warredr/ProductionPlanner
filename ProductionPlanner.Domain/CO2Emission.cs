namespace ProductionPlanner.Domain;
public sealed record CO2Emission(decimal PricePerTonCO2)
{
    public const decimal CO2OutputInTonsPerMWh = 0.3M;
}
