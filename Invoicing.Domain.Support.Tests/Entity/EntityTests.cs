namespace Invoicing.Domain.Support.Tests.Entity;

[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
public class EntityTests
{
    private readonly KellermanSoftware.CompareNetObjects.CompareLogic compareObject = new();
    private readonly Invoicing.Domain.Support.Tests.Entity.Fakes.FakeEntityProperties1 entity = new();
    private readonly Invoicing.Domain.Support.Tests.Entity.Fakes.FakeEntityProperties1 entityCopy;

    public EntityTests()
    {
        entityCopy = entity.Copy<Invoicing.Domain.Support.Tests.Entity.Fakes.FakeEntityProperties1>();
    }

    [Xunit.FactAttribute]
    //public void IsPrime_InputIs1_ReturnFalse()
    public void Copy_InputIsEntity_ReturnNotNull()
    {
        Xunit.Assert.NotNull(entityCopy);
        Xunit.Assert.False(entity.Equals(entityCopy));
    }

    [Xunit.FactAttribute]
    public void Copy_CopyValuesIdenticalWithSource()
    {
        compareObject.Config.MembersToIgnore.Add("ObjectId");

        Xunit.Assert.True(compareObject.Compare(entityCopy, entity).AreEqual);
    }
}