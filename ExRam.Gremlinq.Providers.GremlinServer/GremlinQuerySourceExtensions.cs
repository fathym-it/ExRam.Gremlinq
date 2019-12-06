﻿using System;
using System.Collections.Generic;
using ExRam.Gremlinq.Core;
using ExRam.Gremlinq.Providers.WebSocket;
using Gremlin.Net.Structure.IO.GraphSON;

namespace ExRam.Gremlinq.Providers.GremlinServer
{
    public static class GremlinQuerySourceExtensions
    {
        public static IGremlinQuerySource UseGremlinServer(this IGremlinQuerySource source,
            string hostname,
            GraphsonVersion graphsonVersion,
            int port = 8182,
            bool enableSsl = false,
            string? username = null,
            string? password = null,
            string alias = "g",
            IReadOnlyDictionary<Type, IGraphSONSerializer>? additionalGraphsonSerializers = null,
            IReadOnlyDictionary<string, IGraphSONDeserializer>? additionalGraphsonDeserializers = null)
        {
            return source
                .ConfigureEnvironment(env => env
                    .ConfigureOptions(opt => opt
                        .SetValue(GremlinQuerySerializer.WorkaroundTinkerpop2323, true)))
                .UseWebSocket(
                    hostname,
                    graphsonVersion,
                    port,
                    enableSsl,
                    username,
                    password,
                    alias,
                    additionalGraphsonSerializers,
                    additionalGraphsonDeserializers);
        }
    }
}