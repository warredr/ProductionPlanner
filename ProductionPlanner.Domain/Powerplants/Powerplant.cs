using ProductionPlanner.Domain.Exceptions;
using ProductionPlanner.Domain.Fuels;

namespace ProductionPlanner.Domain.Powerplants;
public abstract class Powerplant
{
    public string Name { get; init; }
    public decimal PMin { get; init; }
    public decimal PMax { get; init; }

    protected readonly decimal _efficiency;
    protected readonly Fuel _fuel;

    public abstract string ExpectedFuelType { get; }

    protected Powerplant(string name, decimal efficiency, decimal pMin, decimal pMax, Fuel fuel)
    {
        Name = name;
        PMin = pMin;
        PMax = pMax;

        _efficiency = efficiency;
        _fuel = fuel;
    }

    public bool CanProvideEnergy(decimal requestedLoad)
    {
        ValidateIfFuelIsPresent();
        return requestedLoad > PMin;
    }

    public virtual decimal TotalPrice()
    {
        ValidateIfFuelIsPresent();
        const decimal conversionFactor = 100;
        return conversionFactor / _efficiency * _fuel.PricePerMWh * PMax;
    }

    protected void ValidateIfFuelIsPresent()
    {
        if (_fuel == null)
        {
            throw new FuelNotAddedException("No fuel has been added yet.");
        }
    }

}
