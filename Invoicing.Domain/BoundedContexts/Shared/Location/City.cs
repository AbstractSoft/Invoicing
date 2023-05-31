namespace Invoicing.Domain.BoundedContexts.Shared.Location;

using Validators;

[Serializable]
public sealed class City : Support.Contracts.ValueObjects.ValueObject
{
    private City()
    {
    }

    public static City MakeCity(
        County county,
        string name)
    {
        var city = new City
        {
            County = county,
            Name = name
        };

        county.ValidateAndThrow();

        return city;
    }

    public County County { get; init; }

    public string Name { get; init; }
    
    public static City NullObject => new()
    {
        Name = "",
        County = County.NullObject
    };

    protected override FluentValidation.IValidator GetValidator()
    {
        return new CityValidator();
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return County;
        yield return Name;
    }
}