﻿using System.Collections.Immutable;
using System.Reflection;

namespace ExRam.Gremlinq.Core
{
    public interface IAssemblyLookupSet : IAssemblyLookupBuilder
    {
        IImmutableSet<Assembly> Assemblies { get; }
    }
}
