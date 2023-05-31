namespace Invoicing.Domain.BoundedContexts.Shared.Location;

using FluentValidation;
using Validators;

[Serializable]
public sealed class AddressesList
    : Support.Contracts.ValueObjects.ValueObjectsList<Address>
{
    protected override IValidator GetValidator()
    {
        return new AddressesListValidator();
    }
}