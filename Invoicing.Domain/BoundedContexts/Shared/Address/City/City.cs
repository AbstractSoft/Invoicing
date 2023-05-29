namespace Invoicing.Domain.BoundedContexts.Shared.Address.City;

[Serializable]
public sealed class City : Support.Contracts.ValueObjects.ValueObject
{
    private City()
    {
    }

    public static City MakeCity(
        County.County county,
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

    public County.County County { get; init; }

    public string Name { get; init; }

    protected override FluentValidation.IValidator GetValidator()
    {
        return new Validators.CityValidator();
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return County;
        yield return Name;
    }
}