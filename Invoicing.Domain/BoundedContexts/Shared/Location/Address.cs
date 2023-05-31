namespace Invoicing.Domain.BoundedContexts.Shared.Location;

using Invoicing.Domain.Support.Contracts.ValueObjects;
using Validators;

public sealed class Address : ValueObject
{
    private Address()
    {
    }

    public static Address MakeAddress(
        Country country,
        County county,
        City city,
        Street street,
        Building building,
        string name = "")
    {
        var address = new Address
        {
            Name = name,
            Country = country,
            County = county,
            City = city,
            Street = street,
            Building = building
        };

        address.ValidateAndThrow();

        return address;
    }

    public string Name { get; init; }
    public Country Country { get; init; }
    public County County { get; init; }
    public City City { get; init; }
    public Street Street { get; init; }
    public Building Building { get; init; }

    public static Address NullObject => new()
    {
        Name = "",
        Country = Location.Country.NullObject,
        County = County.NullObject,
        City = City.NullObject,
        Street = Street.NullObject,
        Building = Building.NullObject
    };

    protected override FluentValidation.IValidator GetValidator()
    {
        return new AddressValidator();
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Name;
        yield return Country;
        yield return County;
        yield return City;
        yield return Street;
        yield return Building;
    }
}