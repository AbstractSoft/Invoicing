namespace Invoicing.Domain.BoundedContexts.Shared.Location.Validators;

using System.Diagnostics.CodeAnalysis;
using FluentValidation;
using Invoicing.Domain.Support.Contracts.Validators;

[ExcludeFromCodeCoverage]
public sealed class AddressesListValidator
    : ValueObjectsListValidator<AddressesList, Address>
{
    public AddressesListValidator()
    {
        RuleForEach(list => list)
            .NotEmpty()
            .SetValidator(new AddressValidator());
    }
}