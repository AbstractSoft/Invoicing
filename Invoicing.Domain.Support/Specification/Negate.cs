namespace Invoicing.Domain.Support.Specification;

public class Negated<T> : Invoicing.Domain.Support.Specification.Contracts.SpecificationBase<T>
{
    private readonly Invoicing.Domain.Support.Specification.Contracts.ISpecification<T> _inner;

    public Negated(Invoicing.Domain.Support.Specification.Contracts.ISpecification<T> inner)
    {
        _inner = inner;
    }

    // NegatedSpecification
    public override System.Linq.Expressions.Expression<Func<T, bool>> SpecExpression
    {
        get
        {
            var objParam = System.Linq.Expressions.Expression.Parameter(typeof(T), "obj");

            var newExpr = System.Linq.Expressions.Expression.Lambda<Func<T, bool>>(
                System.Linq.Expressions.Expression.Not(
                    System.Linq.Expressions.Expression.Invoke(_inner.SpecExpression, objParam)
                ),
                objParam
            );

            return newExpr;
        }
    }
}