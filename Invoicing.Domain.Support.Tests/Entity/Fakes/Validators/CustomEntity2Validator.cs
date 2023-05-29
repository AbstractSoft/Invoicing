namespace Invoicing.Domain.Support.Tests.Entity.Fakes.Validators;

using DefaultValidatorExtensions = FluentValidation.DefaultValidatorExtensions;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class CustomEntity2Validator
    : Invoicing.Domain.Support.Contracts.Validators.EntityValidator<
        CustomEntity2>
{
    public CustomEntity2Validator()
    {
        DefaultValidatorExtensions.NotEmpty(RuleFor(x => x.Property));
        DefaultValidatorExtensions.Length(DefaultValidatorExtensions.NotEmpty(RuleFor(x => x.Property2)), 3);
    }
}