﻿using System.Collections.Immutable;

namespace ExRam.Gremlinq.Core
{
    public sealed class SelectKeysStep : Step
    {
        public SelectKeysStep(ImmutableArray<Key> keys)
        {
            Keys = keys;
        }

        public ImmutableArray<Key> Keys { get; }
    }
}