namespace Invoicing.Domain.Support.Specification;

public class And<T> : Invoicing.Domain.Support.Specification.Contracts.SpecificationBase<T>
{
    private readonly Invoicing.Domain.Support.Specification.Contracts.ISpecification<T> left;
    private readonly Invoicing.Domain.Support.Specification.Contracts.ISpecification<T> right;

    public And(Invoicing.Domain.Support.Specification.Contracts.ISpecification<T> left,
        Invoicing.Domain.Support.Specification.Contracts.ISpecification<T> right)
    {
        this.left = left;
        this.right = right;
    }

    // AndSpecification
    public override System.Linq.Expressions.Expression<Func<T, bool>> SpecExpression
    {
        get
        {
            var objParam = System.Linq.Expressions.Expression.Parameter(typeof(T), "obj");

            var newExpr = System.Linq.Expressions.Expression.Lambda<Func<T, bool>>(
                System.Linq.Expressions.Expression.AndAlso(
                    System.Linq.Expressions.Expression.Invoke(left.SpecExpression, objParam),
                    System.Linq.Expressions.Expression.Invoke(right.SpecExpression, objParam)
                ),
                objParam
            );

            return newExpr;
        }
    }
}