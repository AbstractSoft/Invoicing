namespace Invoicing.Domain.Support.Contracts.ValueObjects;

// Source: https://docs.microsoft.com/en-us/dotnet/standard/microservices-architecture/microservice-ddd-cqrs-patterns/implement-value-objects

public abstract class ValueObject : AbstractBase
{
    public override bool Equals(object? obj)
    {
        if (obj is null || obj.GetType() != GetType()) return false;

        var other = (ValueObject)obj;
        using var thisValues = GetAtomicValues().GetEnumerator();
        using var otherValues = other.GetAtomicValues().GetEnumerator();

        while (thisValues.MoveNext() && otherValues.MoveNext())
        {
            // If either value (but not both) is null, return false
            if (thisValues.Current is null ^ otherValues.Current is null)
            {
                return false;
            }

            switch (thisValues.Current)
            {
                // If both values are null, move to next
                case null:
                    continue;
                // If both values are index-able, check for sequential equality
                case System.Collections.IList thisList when otherValues.Current is System.Collections.IList otherList:
                {
                    var thisGenList = thisList.Cast<object>();
                    var otherGenList = otherList.Cast<object>();
                    if (!thisGenList.SequenceEqual(otherGenList)) return false;

                    break;
                }
                // If both values are enumerable but not index-able, check for collection equality
                case System.Collections.IEnumerable thisCollection
                    when otherValues.Current is System.Collections.IEnumerable otherCollection:
                {
                    var thisGenCollection = thisCollection.Cast<object>().ToList();
                    var otherGenCollection = otherCollection.Cast<object>().ToList();
                    // If the collections contain different amounts of elements or collection B does not contain all of collection A's elements, return false
                    if (thisGenCollection.Count != otherGenCollection.Count
                        || !thisGenCollection.All(thisElement =>
                            otherGenCollection.Any(otherElement =>
                                Equals(thisElement, otherElement))))
                        return false;

                    break;
                }
                default:
                {
                    if (!thisValues.Current.Equals(otherValues.Current)) return false;

                    break;
                }
            }
        }

        return true;
    }

    public override int GetHashCode()
    {
        return GetAtomicValues().Aggregate(92821, (result, obj) =>
        {
            // https://github.com/dotnet/roslyn/blob/master/src/Compilers/Test/Resources/Core/NetFX/ValueTuple/ValueTuple.cs#L11
            var rol5 = ((uint)result << 5) | ((uint)result >> 27);
            return ((int)rol5 + result) ^ obj?.GetHashCode() ?? 0;
        });
    }

    protected abstract IEnumerable<object> GetAtomicValues();
}