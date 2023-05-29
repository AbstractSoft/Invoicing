namespace Invoicing.Domain.Support.Contracts.ValueObjects;

using System.Collections.Generic;

public abstract class ReadOnlyValueObjectsList<T> : Invoicing.Domain.Support.Contracts.ValueObjects.ValueObjectsList<T>
    where T : Invoicing.Domain.Support.Contracts.ValueObjects.ValueObject
{
    protected ReadOnlyValueObjectsList(IEnumerable<T> list)
    {
        AddRange(list);
        IsReadOnly = true;
    }
}