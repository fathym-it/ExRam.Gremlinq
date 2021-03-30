﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ExRam.Gremlinq.Core
{
    public static class GremlinQueryExecutionResultDeserializer
    {
        private sealed class GremlinQueryExecutionResultDeserializerImpl : IGremlinQueryExecutionResultDeserializer
        {
            private readonly IGremlinQueryFragmentDeserializer _fragmentSerializer;

            public GremlinQueryExecutionResultDeserializerImpl(IGremlinQueryFragmentDeserializer fragmentSerializer)
            {
                _fragmentSerializer = fragmentSerializer;
            }

            public IAsyncEnumerable<TElement> Deserialize<TElement>(object executionResult, IGremlinQueryEnvironment environment)
            {
                var result = _fragmentSerializer
                    .TryDeserialize(executionResult, typeof(TElement[]), environment);

                return result switch
                {
                    TElement[] elements => elements.ToAsyncEnumerable(),
                    IAsyncEnumerable<TElement> enumerable => enumerable,
                    TElement element => new[] { element }.ToAsyncEnumerable(),
                    IEnumerable enumerable => enumerable
                        .Cast<TElement>()
                        .Where(x => x is not null)
                        .Select(x => x!)
                        .ToAsyncEnumerable(),
                    { } obj => throw new InvalidCastException($"A result of type {obj.GetType()} can't be interpreted as {nameof(IAsyncEnumerable<TElement>)}."),
                    _ => AsyncEnumerable.Empty<TElement>()
                };
            }

            public IGremlinQueryExecutionResultDeserializer ConfigureFragmentDeserializer(Func<IGremlinQueryFragmentDeserializer, IGremlinQueryFragmentDeserializer> transformation)
            {
                return new GremlinQueryExecutionResultDeserializerImpl(transformation(_fragmentSerializer));
            }
        }

        private sealed class InvalidQueryExecutionResultDeserializer : IGremlinQueryExecutionResultDeserializer
        {
            public IAsyncEnumerable<TElement> Deserialize<TElement>(object result, IGremlinQueryEnvironment environment)
            {
                throw new InvalidOperationException($"{nameof(Deserialize)} must not be called on {nameof(GremlinQueryExecutionResultDeserializer)}.{nameof(Invalid)}. If you are getting this exception while executing a query, configure a proper {nameof(IGremlinQueryExecutionResultDeserializer)} on your {nameof(GremlinQuerySource)}.");
            }

            public IGremlinQueryExecutionResultDeserializer ConfigureFragmentDeserializer(Func<IGremlinQueryFragmentDeserializer, IGremlinQueryFragmentDeserializer> transformation)
            {
                throw new InvalidOperationException($"{nameof(ConfigureFragmentDeserializer)} cannot be called on {nameof(GremlinQueryExecutionResultDeserializer)}.{nameof(Invalid)}.");
            }
        }

        public static readonly IGremlinQueryExecutionResultDeserializer Identity = new GremlinQueryExecutionResultDeserializerImpl(GremlinQueryFragmentDeserializer.Identity);

        public static readonly IGremlinQueryExecutionResultDeserializer Invalid = new InvalidQueryExecutionResultDeserializer();

        public static readonly IGremlinQueryExecutionResultDeserializer Default = Identity
            .ConfigureFragmentDeserializer(_ => _
                .Override<object>((data, type, env, overridden, recurse) =>
                {
                    if (type.IsInstanceOfType(data))
                        return data;

                    if (type.IsArray)
                    {
                        var elementType = type.GetElementType()!;
                        var ret = Array.CreateInstance(elementType, 1);

                        ret
                            .SetValue(recurse.TryDeserialize(data, elementType, env), 0);

                        return ret;
                    }

                    return overridden(data, type, env, recurse);
                })
                .AddToStringFallback());

        [Obsolete("To be removed in an upcoming major release. To still get this functionality, refer to https://github.com/ExRam/ExRam.Gremlinq/blob/92f546ff65cf3306be51566641b8512c71d1eac0/src/ExRam.Gremlinq.Core/Deserialization/GremlinQueryExecutionResultDeserializer.cs#L85.")]
        public static readonly IGremlinQueryExecutionResultDeserializer ToGraphsonString = Default
            .ConfigureFragmentDeserializer(_ => _
                .ToGraphsonString());

        [Obsolete("Use GremlinQueryExecutionResultDeserializer.Identity.ConfigureFragmentDeserializer(_ => _.AddToStringFallback()) instead.")]
        public static new readonly IGremlinQueryExecutionResultDeserializer ToString = Default;

        [Obsolete("Use GremlinQueryExecutionResultDeserializer.Identity.ConfigureFragmentDeserializer(_ => _.AddNewtonsoftJson()) instead.")]
        public static readonly IGremlinQueryExecutionResultDeserializer FromJToken = Default
            .ConfigureFragmentDeserializer(_ => _
                .AddNewtonsoftJson());
    }
}
