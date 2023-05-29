namespace Invoicing.Domain.Support.Specification;

public static class Extensions
{
    public static Invoicing.Domain.Support.Specification.Contracts.ISpecification<T> And<T>(
        this Invoicing.Domain.Support.Specification.Contracts.ISpecification<T> left,
        Invoicing.Domain.Support.Specification.Contracts.ISpecification<T> right)
    {
        return new And<T>(left, right);
    }

    public static Invoicing.Domain.Support.Specification.Contracts.ISpecification<T> Or<T>(
        this Invoicing.Domain.Support.Specification.Contracts.ISpecification<T> left,
        Invoicing.Domain.Support.Specification.Contracts.ISpecification<T> right)
    {
        return new Or<T>(left, right);
    }

    public static Invoicing.Domain.Support.Specification.Contracts.ISpecification<T> Negate<T>(
        this Invoicing.Domain.Support.Specification.Contracts.ISpecification<T> inner)
    {
        return new Negated<T>(inner);
    }
}