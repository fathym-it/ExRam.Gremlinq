﻿#if RELEASE && NETCOREAPP3_1
using ExRam.Gremlinq.Core;
using ExRam.Gremlinq.Core.Tests;
using ExRam.Gremlinq.Providers.WebSocket;
using Xunit.Abstractions;
using static ExRam.Gremlinq.Core.GremlinQuerySource;

namespace ExRam.Gremlinq.Providers.GremlinServer.Tests
{
    public class GremlinServerIntegrationTests : QueryIntegrationTest
    {
        public GremlinServerIntegrationTests(ITestOutputHelper testOutputHelper) : base(
            g
                .ConfigureEnvironment(env => env
                    .UseGremlinServer(builder => builder
                        .AtLocalhost())
                    .UseDeserializer(GremlinQueryExecutionResultDeserializer.Identity)),
            testOutputHelper)
        {
        }
    }
}
#endif
