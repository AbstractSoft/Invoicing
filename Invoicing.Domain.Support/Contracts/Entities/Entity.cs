namespace Invoicing.Domain.Support.Contracts.Entities;

public abstract class Entity : AbstractBase
{
    protected Entity()
        : this(Guid.NewGuid())
    {
    }

    protected Entity(Guid objectId)
    {
        ObjectId = objectId;
    }

    public Guid ObjectId { get; }
}