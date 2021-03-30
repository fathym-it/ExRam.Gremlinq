﻿using System;
using Gremlin.Net.Process.Traversal;

namespace ExRam.Gremlinq.Core
{
    public sealed class RangeStep : Step
    {
        public RangeStep(long lower, long upper, Scope scope)
        {
            if (lower < 0)
                throw new ArgumentOutOfRangeException(nameof(lower));

            if (upper < -1)
                throw new ArgumentException(nameof(upper));

            Lower = lower;
            Upper = upper;
            Scope = scope;
        }

        public long Lower { get; }
        public long Upper { get; }
        public Scope Scope { get; }
    }
}
