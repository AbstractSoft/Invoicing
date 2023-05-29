namespace Invoicing.Domain.Support.Tests.Entity.Fakes.Validators;

using DefaultValidatorExtensions = FluentValidation.DefaultValidatorExtensions;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class CustomEntityValidator
    : Invoicing.Domain.Support.Contracts.Validators.EntityValidator<
        CustomEntity>
{
    public CustomEntityValidator()
    {
        DefaultValidatorExtensions.NotEmpty(RuleFor(x => x.StringProperty));
        DefaultValidatorExtensions.Length(DefaultValidatorExtensions.NotEmpty(RuleFor(x => x.StringProperty2)), 3);
        DefaultValidatorExtensions.NotNull(RuleFor(x => x.CustomEntity2))
            .SetValidator(new CustomEntity2Validator());
    }
}