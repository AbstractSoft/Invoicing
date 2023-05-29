namespace Invoicing.Domain.Support.Tests.Entity.Fakes;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class CustomEntity2 : Invoicing.Domain.Support.Contracts.Entities.Entity
{
    public CustomEntity2()
        : this(Guid.NewGuid())
    {
    }

    public CustomEntity2(Guid id)
        : base(id)
    {
        Property = Invoicing.Domain.Support.Helpers.Constants.GetNullString();
        Property2 = Invoicing.Domain.Support.Helpers.Constants.GetNullString();
    }

    public string Property { get; set; }
    public string Property2 { get; set; }

    protected override FluentValidation.IValidator GetValidator()
    {
        return new Invoicing.Domain.Support.Tests.Entity.Fakes.Validators.CustomEntity2Validator();
    }
}