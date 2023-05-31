namespace Invoicing.Domain.BoundedContexts.Shared.Location;

[Serializable]
public sealed class County : Support.Contracts.ValueObjects.ValueObject
{
    private County()
    {
    }

    public static County MakeCounty(
        Country country,
        string name,
        string code)
    {
        var county = new County
        {
            Country = country,
            Name = name,
            Code = code
        };

        county.ValidateAndThrow();

        return county;
    }

    public Country Country { get; init; }

    public string Name { get; init; }
    public string Code { get; init; }
    
    public static County NullObject => new()
    {
        Name = "",
        Code = "",
        Country = Country.NullObject
    };

    protected override FluentValidation.IValidator GetValidator()
    {
        return new Validators.CountyValidator();
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Country;
        yield return Name;
        yield return Code;
    }
}