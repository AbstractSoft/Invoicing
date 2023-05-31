﻿namespace Invoicing.Domain.Support.Specification;

public class And<T> : Contracts.SpecificationBase<T>
{
    private readonly Contracts.ISpecification<T> left;
    private readonly Contracts.ISpecification<T> right;

    public And(Contracts.ISpecification<T> left,
        Contracts.ISpecification<T> right)
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