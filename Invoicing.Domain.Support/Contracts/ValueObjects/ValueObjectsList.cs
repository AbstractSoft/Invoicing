namespace Invoicing.Domain.Support.Contracts.ValueObjects;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public abstract class ValueObjectsList<T> : ValueObject, IList<T>
    where T : ValueObject
{
    private const string ErrMsgOperationIsNotPermittedOnAReadonlyList = "This operation is not allowed on a ReadOnly list!";

    private readonly IList<T> valueObjects;

    protected ValueObjectsList()
    {
        valueObjects = new List<T>();
    }
        
    public int IndexOf(T item)
    {
        return valueObjects.IndexOf(item);
    }

    public void Insert(int index, T item)
    {
        CheckIfListIsReadonly();
        if (CheckIfValueObjectAlreadyExist(item))
        {
            return;
        }

        valueObjects.Insert(index, item);
    }

    public void RemoveAt(int index)
    {
        CheckIfListIsReadonly();
        valueObjects.RemoveAt(index);
    }

    public T this[int index]
    {
        get => valueObjects[index];
        set
        {
            CheckIfListIsReadonly();
            valueObjects[index] = value;
        }
    }

    public void Add(T item)
    {
        if (item == null || item.Equals(default(T)))
        {
            throw new ArgumentNullException(nameof(item));
        }

        CheckIfListIsReadonly();
        if (CheckIfValueObjectAlreadyExist(item))
        {
            return;
        }

        valueObjects.Add(item);
    }

    public void AddRange(IEnumerable<T> collection)
    {
        if (collection == null)
        {
            throw new ArgumentNullException(nameof(collection));
        }

        CheckIfListIsReadonly();
        foreach (var item in collection)
        {
            Add(item);
        }
    }

    public void Clear()
    {
        CheckIfListIsReadonly();
        valueObjects.Clear();
    }

    public bool Contains(T item)
    {
        return valueObjects.Contains(item);
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        valueObjects.CopyTo(array, arrayIndex);
    }

    public int Count => valueObjects.Count;

    public bool IsReadOnly { get; protected init; }

    public bool Remove(T item)
    {
        CheckIfListIsReadonly();
        return valueObjects.Remove(item);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return valueObjects.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private void CheckIfListIsReadonly()
    {
        if (IsReadOnly)
        {
            throw new InvalidOperationException(ErrMsgOperationIsNotPermittedOnAReadonlyList);
        }
    }

    private bool CheckIfValueObjectAlreadyExist(T item)
    {
        return valueObjects.Contains(item);
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || obj.GetType() != GetType())
        {
            return false;
        }

        var otherList = (ValueObjectsList<T>)obj;

        if (Count != otherList.Count)
        {
            return false;
        }

        for (var i = 0; i < Count - 1; i++)
        {
            if (!this[0].Equals(otherList[0]))
            {
                return false;
            }
        }

        return true;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        return this.Select(item => item.GetHashCode()).Cast<object>();
    }

    public override int GetHashCode()
    {
        var atomicValues = GetAtomicValues().ToArray();
        if (atomicValues.Length == 0)
        {
            return 0; //Aggregate throws exception if list is empty
        }

        return atomicValues.Select(x => x != null ? x.GetHashCode() : 0)
            .Aggregate((x, y) => x ^ y);
    }

    public IEnumerable<T> ToList()
    {
        return valueObjects
            .Select(valueObject => valueObject.Copy<T>())
            .ToList();
    }
}