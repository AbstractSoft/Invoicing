namespace Invoicing.Domain.BoundedContexts.Shared.Addresses;

using FluentValidation;
using Invoicing.Domain.BoundedContexts.Shared.Address.Validators;

[Serializable]
public sealed class AddressesList
    : Support.Contracts.ValueObjects.ValueObjectsList<Address.Address>
{
    protected override IValidator GetValidator()
    {
        return new AddressesListValidator();
    }
}