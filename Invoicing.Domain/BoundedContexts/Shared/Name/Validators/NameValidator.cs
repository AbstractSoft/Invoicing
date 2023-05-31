namespace Invoicing.Domain.BoundedContexts.Shared.Name.Validators;

using System.Diagnostics.CodeAnalysis;
using FluentValidation;
using Support.Contracts.Validators;

[ExcludeFromCodeCoverage]
public class NameValidator : ValueObjectValidator<Name>
{
    public NameValidator()
    {
        RuleFor(n => n.FullName)
            .NotEmpty()
            .MaximumLength(50);
    }
}