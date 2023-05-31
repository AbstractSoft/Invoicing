namespace Invoicing.Domain.Support.Specification;

public static class Extensions
{
    public static Contracts.ISpecification<T> And<T>(
        this Contracts.ISpecification<T> left,
        Contracts.ISpecification<T> right)
    {
        return new And<T>(left, right);
    }

    public static Contracts.ISpecification<T> Or<T>(
        this Contracts.ISpecification<T> left,
        Contracts.ISpecification<T> right)
    {
        return new Or<T>(left, right);
    }

    public static Contracts.ISpecification<T> Negate<T>(
        this Contracts.ISpecification<T> inner)
    {
        return new Negated<T>(inner);
    }
}