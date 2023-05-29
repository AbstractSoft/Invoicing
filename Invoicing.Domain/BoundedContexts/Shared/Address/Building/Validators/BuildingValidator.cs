namespace Invoicing.Domain.BoundedContexts.Shared.Address.Building.Validators;

using System.Diagnostics.CodeAnalysis;
using FluentValidation;
using Invoicing.Domain.Support.Contracts.Validators;

[ExcludeFromCodeCoverage]
public sealed class BuildingValidator :
    ValueObjectValidator<Building>
{
    public BuildingValidator()
    {
        RuleFor(b => b.Name)
            .MaximumLength(50);
        RuleFor(b => b.Number)
            .MaximumLength(10);
        RuleFor(b => b.Entrance)
            .MaximumLength(5);
        RuleFor(b => b.Floor)
            .MaximumLength(10);
        RuleFor(b => b.Apartment)
            .MaximumLength(5);
        RuleFor(b => b).Must(f =>
            !string.IsNullOrEmpty(f.Name) ||
            !string.IsNullOrEmpty(f.Number) ||
            !string.IsNullOrEmpty(f.Entrance) ||
            !string.IsNullOrEmpty(f.Floor) ||
            !string.IsNullOrEmpty(f.Apartment)
        );
    }
}