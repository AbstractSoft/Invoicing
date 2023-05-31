namespace Invoicing.Domain.Support.Tests.Entity;

using System.Diagnostics.CodeAnalysis;
using Xunit;

[ExcludeFromCodeCoverage]
public class EntityTests
{
    private readonly KellermanSoftware.CompareNetObjects.CompareLogic _compareObject = new();
    private readonly Fakes.FakeEntityProperties1 _entity = new();
    private readonly Fakes.FakeEntityProperties1 _entityCopy;

    public EntityTests()
    {
        _entityCopy = _entity.Copy<Fakes.FakeEntityProperties1>();
    }

    [Fact]
    public void Copy_InputIsEntity_ReturnNotNull()
    {
        Assert.NotNull(_entityCopy);
        Assert.False(_entity.Equals(_entityCopy));
    }

    [Fact]
    public void Copy_CopyValuesIdenticalWithSource()
    {
        _compareObject.Config.MembersToIgnore.Add("ObjectId");

        Assert.True(_compareObject.Compare(_entityCopy, _entity).AreEqual);
    }
}