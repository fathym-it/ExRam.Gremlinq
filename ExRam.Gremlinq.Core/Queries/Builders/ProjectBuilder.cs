﻿using System;
using System.Collections.Immutable;
using System.Linq.Expressions;
using LanguageExt;

namespace ExRam.Gremlinq.Core
{
    public static class ProjectBuilder
    {
        private sealed class ProjectBuilderImpl<TSourceQuery, TElement> : IProjectTupleBuilder<TSourceQuery, TElement> where TSourceQuery : IGremlinQuery<TElement>
        {
            private readonly TSourceQuery _sourceQuery;

            public ProjectBuilderImpl(TSourceQuery sourceQuery, IImmutableDictionary<string, IGremlinQuery> projections)
            {
                _sourceQuery = sourceQuery;
                Projections = projections;
            }
            
            IProjectBuilder<TSourceQuery, TElement> IProjectBuilder<TSourceQuery, TElement>.By(Func<TSourceQuery, IGremlinQuery> projection)
            {
                return By(projection);
            }

            IProjectBuilder<TSourceQuery, TElement> IProjectBuilder<TSourceQuery, TElement>.By(string name, Func<TSourceQuery, IGremlinQuery> projection)
            {
                return By(name, projection);
            }

            IProjectTupleBuilder<TSourceQuery, TElement> IProjectTupleBuilder<TSourceQuery, TElement>.By(Func<TSourceQuery, IGremlinQuery> projection)
            {
                return By(projection);
            }

            private ProjectBuilderImpl<TSourceQuery, TElement> By( Func<TSourceQuery, IGremlinQuery> projection)
            {
                return By($"Item{Projections.Count + 1}", projection);
            }

            private ProjectBuilderImpl<TSourceQuery, TElement> By(string name, Func<TSourceQuery, IGremlinQuery> projection)
            {
                return new ProjectBuilderImpl<TSourceQuery, TElement>(
                    _sourceQuery,
                    Projections.SetItem(name, projection(_sourceQuery)));
            }
            
            public IImmutableDictionary<string, IGremlinQuery> Projections { get; }

            IImmutableDictionary<string, IGremlinQuery> IProjectBuilder<TSourceQuery, TElement>.Projections => throw new NotImplementedException();
        }

        internal static IProjectTupleBuilder<TSourceQuery, TElement> Create<TSourceQuery, TElement>(TSourceQuery sourceQuery) where TSourceQuery : IGremlinQuery<TElement>
        {
            return new ProjectBuilderImpl<TSourceQuery, TElement>(sourceQuery, ImmutableDictionary<string, IGremlinQuery>.Empty);
        }

        public static IProjectBuilder<TSourceQuery, TElement> By<TSourceQuery, TElement>(this IProjectBuilder<TSourceQuery, TElement> projectBuilder, Expression<Func<TElement, object>> projection)
            where TSourceQuery : IElementGremlinQuery<TElement>
        {
            if (projection.Body.StripConvert() is MemberExpression memberExpression)
                return projectBuilder.By(memberExpression.Member.Name, _ => _.Values(projection));

            throw new ExpressionNotSupportedException(projection);
        }
    }
}
