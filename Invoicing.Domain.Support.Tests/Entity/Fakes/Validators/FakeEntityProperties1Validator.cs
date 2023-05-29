namespace Invoicing.Domain.Support.Tests.Entity.Fakes.Validators;

using DefaultValidatorExtensions = FluentValidation.DefaultValidatorExtensions;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class FakeEntityProperties1Validator
    : Invoicing.Domain.Support.Contracts.Validators.EntityValidator<FakeEntityProperties1>
{
    public FakeEntityProperties1Validator()
    {
        DefaultValidatorExtensions.NotEmpty(RuleFor(x => x.StringProperty));
    }
}