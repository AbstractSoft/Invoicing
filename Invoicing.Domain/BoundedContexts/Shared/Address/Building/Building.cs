namespace Invoicing.Domain.BoundedContexts.Shared.Address.Building;

using Support.Contracts.ValueObjects;
using Validators;

public sealed class Building : ValueObject
{
    private Building()
    {
    }

    public static Building MakeBuilding(
        string name = "",
        string number = "",
        string entrance = "",
        string floor = "",
        string apartment = "")
    {
        var building = new Building
        {
            Name = name,
            Number = number,
            Entrance = entrance,
            Floor = floor,
            Apartment = apartment
        };

        building.ValidateAndThrow();

        return building;
    }

    public string Name { get; private init; }
    public string Number { get; private init; }
    public string Entrance { get; private init; }
    public string Floor { get; private init; }
    public string Apartment { get; private init; }

    protected override FluentValidation.IValidator GetValidator()
    {
        return new BuildingValidator();
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Name;
        yield return Number;
        yield return Entrance;
        yield return Floor;
        yield return Apartment;
    }
}