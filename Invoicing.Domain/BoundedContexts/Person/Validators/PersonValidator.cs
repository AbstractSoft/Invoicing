namespace Invoicing.Domain.BoundedContexts.Person.Validators;

using System.Diagnostics.CodeAnalysis;
using FluentValidation;
using IDCard.Validators;
using Invoicing.Domain.Support.Contracts.Validators;
using Shared.BankAccount.Validators;
using Shared.Location.Validators;
using Shared.Name.Validators;

[ExcludeFromCodeCoverage]
public sealed class PersonValidator : EntityValidator<Person>
{
    public PersonValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .SetValidator(new NameValidator());
        
        RuleFor(p => p.IDCard)
            .NotEmpty()
            .SetValidator(new IDCardValidator());

        RuleFor(p => p.Address)
            .NotEmpty()
            .SetValidator(new AddressValidator());
        
        RuleFor(p => p.BankAccount)
            .NotEmpty()
            .SetValidator(new BankAccountValidator());
    }
}