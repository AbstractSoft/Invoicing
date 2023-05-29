namespace Invoicing.Domain.Support.Tests.Entity.Fakes;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class CustomEntity : Invoicing.Domain.Support.Contracts.Entities.Entity
{
    public CustomEntity()
        : this(Guid.NewGuid())
    {
    }

    public CustomEntity(Guid id)
        : base(id)
    {
        StringProperty = Invoicing.Domain.Support.Helpers.Constants.GetNullString();
        StringProperty2 = Invoicing.Domain.Support.Helpers.Constants.GetNullString();
        IntProperty = default;
        DateTimeProperty = default;
        CustomEntity2 = Invoicing.Domain.Support.Helpers.Constants.GetNullObject<CustomEntity2>();
    }

    public string StringProperty { get; set; }
    public string StringProperty2 { get; set; }
    public int IntProperty { get; set; }
    public DateTime DateTimeProperty { get; set; }
    public CustomEntity2 CustomEntity2 { get; set; }

    protected override FluentValidation.IValidator GetValidator()
    {
        return new Invoicing.Domain.Support.Tests.Entity.Fakes.Validators.CustomEntityValidator();
    }
}