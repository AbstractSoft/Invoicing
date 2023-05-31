namespace Invoicing.Domain.Support.Contracts.Validators
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using FluentValidation;

    public abstract class ReadOnlyValueObjectsListValidator<TList, TListItem> : AbstractValidator<TList>
        where TList : ValueObjects.ReadOnlyValueObjectsList<TListItem>
        where TListItem : ValueObjects.ValueObject
    {
        public new IRuleBuilderInitialCollection<TList, TProperty> RuleForEach<TProperty>(
            Expression<Func<TList, IEnumerable<TProperty>>> expression)
        {
            return base.RuleForEach(expression);
        }
    }
}