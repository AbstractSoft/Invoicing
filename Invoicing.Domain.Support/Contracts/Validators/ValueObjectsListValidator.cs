namespace Invoicing.Domain.Support.Contracts.Validators
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using FluentValidation;

    public abstract class ValueObjectsListValidator<TList, TListItem> : AbstractValidator<TList>
        where TList : ValueObjects.ValueObjectsList<TListItem>
        where TListItem : ValueObjects.ValueObject
    {
        public new IRuleBuilderInitialCollection<TList, TProperty> RuleForEach<TProperty>(
            Expression<Func<TList, IEnumerable<TProperty>>> expression)
        {
            return base.RuleForEach(expression);
        }
    }
}