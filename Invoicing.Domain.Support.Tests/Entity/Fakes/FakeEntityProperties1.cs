namespace Invoicing.Domain.Support.Tests.Entity.Fakes;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class FakeEntityProperties1 : Invoicing.Domain.Support.Contracts.Entities.Entity
{
    public FakeEntityProperties1()
        : this(Guid.NewGuid())
    {
    }

    public FakeEntityProperties1(Guid id)
        : base(id)
    {
        StringProperty = Helpers.Constants.GetNullString();
        IntProperty = default;
        DateTimeProperty = default;
        CustomObjectsList = new List<CustomEntity>(3);

        InitFakeEntityProperties1();
    }

    public string StringProperty { get; set; }
    private int IntProperty { get; set; }
    private DateTime DateTimeProperty { get; set; }
    private List<CustomEntity> CustomObjectsList { get; set; }

    private void InitFakeEntityProperties1()
    {
        StringProperty = "StringPropertyValue";
        IntProperty = 1;
        DateTimeProperty = DateTime.Now;
        CustomObjectsList = new List<CustomEntity>(3);

        CustomObjectsList.AddRange(new List<CustomEntity>
        {
            new()
            {
                StringProperty = "entity1",
                IntProperty = 100,
                DateTimeProperty = new DateTime(2015, 9, 1)
            },
            new()
            {
                StringProperty = "entity2",
                IntProperty = 200,
                DateTimeProperty = new DateTime(2015, 9, 2)
            },
            new()
            {
                StringProperty = "entity3",
                IntProperty = 300,
                DateTimeProperty = new DateTime(2015, 9, 3)
            }
        });
    }

    protected override FluentValidation.IValidator GetValidator()
    {
        return new Validators.FakeEntityProperties1Validator();
    }
}