﻿using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace ExRam.Gremlinq.Core
{
    public abstract class LogicalStep<TStep> : Step
        where TStep : LogicalStep<TStep>
    {
        protected LogicalStep(string name, IEnumerable<Traversal> traversals)
        {
            Name = name;
            Traversals = traversals
                .SelectMany(FlattenLogicalTraversals)
                .ToImmutableArray();
        }

        private static IEnumerable<Traversal> FlattenLogicalTraversals(Traversal traversal)
        {
            if (traversal.Steps.Length == 1 && traversal.Steps[0] is TStep otherStep)
            {
                foreach (var subTraversal in otherStep.Traversals)
                {
                    foreach (var flattenedSubTraversal in FlattenLogicalTraversals(subTraversal))
                    {
                        yield return flattenedSubTraversal;
                    }
                }
            }
            else
                yield return traversal;
        }

        public string Name { get; }
        public ImmutableArray<Traversal> Traversals { get; }
    }
}
