﻿using System.Linq.Expressions;
using Dev.Core.Specification.Expressions;

namespace Dev.Core.Specification.Builder;

public static class OrderedBuilderExtensions
{
    public static IOrderedSpecificationBuilder<T> ThenBy<T>(
        this IOrderedSpecificationBuilder<T> orderedBuilder,
        Expression<Func<T, object?>> orderExpression)
        => ThenBy(orderedBuilder, orderExpression, true);

    public static IOrderedSpecificationBuilder<T> ThenBy<T>(
        this IOrderedSpecificationBuilder<T> orderedBuilder,
        Expression<Func<T, object?>> orderExpression,
        bool condition)
    {
        if (condition && !orderedBuilder.IsChainDiscarded)
        {
            ((List<OrderExpressionInfo<T>>)orderedBuilder.Specification.OrderExpressions).Add(new OrderExpressionInfo<T>(orderExpression, OrderTypeEnum.ThenBy));
        }
        else
        {
            orderedBuilder.IsChainDiscarded = true;
        }

        return orderedBuilder;
    }

    public static IOrderedSpecificationBuilder<T> ThenByDescending<T>(
        this IOrderedSpecificationBuilder<T> orderedBuilder,
        Expression<Func<T, object?>> orderExpression)
        => ThenByDescending(orderedBuilder, orderExpression, true);

    public static IOrderedSpecificationBuilder<T> ThenByDescending<T>(
        this IOrderedSpecificationBuilder<T> orderedBuilder,
        Expression<Func<T, object?>> orderExpression,
        bool condition)
    {
        if (condition && !orderedBuilder.IsChainDiscarded)
        {
            ((List<OrderExpressionInfo<T>>)orderedBuilder.Specification.OrderExpressions).Add(new OrderExpressionInfo<T>(orderExpression, OrderTypeEnum.ThenByDescending));
        }
        else
        {
            orderedBuilder.IsChainDiscarded = true;
        }

        return orderedBuilder;
    }
}
