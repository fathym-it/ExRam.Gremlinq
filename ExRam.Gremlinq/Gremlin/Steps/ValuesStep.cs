﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Linq.Expressions;
using LanguageExt;

namespace ExRam.Gremlinq
{
    public sealed class ValuesStep<TSource, TTarget> : NonTerminalStep
    {
        private readonly Expression<Func<TSource, TTarget>>[] _projections;

        public ValuesStep(Expression<Func<TSource, TTarget>>[] projections)
        {
            _projections = projections;
        }

        public override IEnumerable<Step> Resolve(IGraphModel model)
        {
            var keys = _projections
                .Select(projection =>
                {
                    if (projection.Body.StripConvert() is MemberExpression memberExpression)
                        return model.GetIdentifier(memberExpression.Member.Name);

                    throw new NotSupportedException();
                })
                .ToArray();

            var numberOfIdSteps = keys
                .OfType<T>()
                .Count(x => x == T.Id);

            var propertyKeys = keys
                .OfType<string>()
                .Cast<object>()
                .ToArray();

            if (numberOfIdSteps > 1 || numberOfIdSteps > 0 && propertyKeys.Length > 0)
            {
                yield return new ResolvedMethodStep("union",
                    GremlinQuery.Anonymous.AddStep(new ResolvedMethodStep("values", propertyKeys)).Resolve(model),
                    GremlinQuery.Anonymous.Id().Resolve(model));
            }
            else if (numberOfIdSteps > 0)
                yield return ResolvedMethodStep.Id;
            else
            {
                yield return new ResolvedMethodStep(
                    "values",
                    propertyKeys);
            }
        }
    }
}
