namespace Invoicing.Domain.Support.Contracts.ValueObjects;

using System.Collections.Generic;

public abstract class ReadOnlyValueObjectsList<T> : ValueObjectsList<T>
    where T : ValueObject
{
    protected ReadOnlyValueObjectsList(IEnumerable<T> list)
    {
        AddRange(list);
        IsReadOnly = true;
    }
}