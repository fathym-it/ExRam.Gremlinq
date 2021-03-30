﻿using System;
using Gremlin.Net.Process.Traversal;

namespace ExRam.Gremlinq.Core
{
    public sealed class SkipStep : Step
    {
        public SkipStep(long count, Scope scope)
        {
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            Count = count;
            Scope = scope;
        }

        public long Count { get; }
        public Scope Scope { get; }
    }
}
