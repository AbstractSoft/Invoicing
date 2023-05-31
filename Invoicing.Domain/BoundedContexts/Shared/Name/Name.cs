namespace Invoicing.Domain.BoundedContexts.Shared.Name;

using FluentValidation;
using Support.Contracts.ValueObjects;
using Validators;

[Serializable]
public class Name : ValueObject
{
    private Name()
    {
    }

    public static Name MakeName(
        string firstName,
        string lastName)
    {
        var name = new Name
        {
            FullName = string.Format($"{lastName} {firstName}")
        };

        name.ValidateAndThrow();

        return name;
    }

    public static Name MakeName(string fullName)
    {
        var name = new Name
        {
            FullName = fullName
        };

        name.ValidateAndThrow();

        return name;
    }

    public string FullName { get; init; }

    protected override IValidator GetValidator()
    {
        return new NameValidator();
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return FullName;
    }
}