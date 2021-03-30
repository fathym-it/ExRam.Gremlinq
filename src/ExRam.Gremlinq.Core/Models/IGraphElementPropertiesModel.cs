using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Reflection;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ExRam.Gremlinq.Core
{
    public interface IGraphElementPropertyModel
    {
        IGraphElementPropertyModel ConfigureCustomSerializers(Func<IList<IGraphElementPropertySerializer>, IList<IGraphElementPropertySerializer>> transformation);

        IGraphElementPropertyModel ConfigureMemberMetadata(Func<IImmutableDictionary<MemberInfo, MemberMetadata>, IImmutableDictionary<MemberInfo, MemberMetadata>> transformation);

        IImmutableDictionary<MemberInfo, MemberMetadata> MemberMetadata { get; }

        IList<IGraphElementPropertySerializer> CustomSerializers { get; }
    }

    public interface IGraphElementPropertySerializer
    {
        Func<JToken, object> Deserialize { get; }

        Func<object, IDictionary<string, string>> Serialize { get; }

        Func<Type, bool> ShouldDeserialize { get; }

        Func<PropertyInfo, bool> ShouldSerialize { get; }
    }

    public class GraphElementPropertySerializer : IGraphElementPropertySerializer
    {
        public GraphElementPropertySerializer(Func<PropertyInfo, bool> shouldSerialize, Func<object, IDictionary<string, string>> serialize,
            Func<Type, bool> shouldDeserialize, Func<JToken, object> deserialize)
        {
            Deserialize = deserialize;

            Serialize = serialize;

            ShouldDeserialize = shouldDeserialize;

            ShouldSerialize = shouldSerialize;
        }

        public virtual Func<JToken, object> Deserialize { get; protected set; }

        public virtual Func<object, IDictionary<string, string>> Serialize { get; protected set; }

        public virtual Func<Type, bool> ShouldDeserialize { get; protected set; }

        public virtual Func<PropertyInfo, bool> ShouldSerialize { get; protected set; }
    }

    public class GenericGraphElementPropertySerializer<T> : GenericGraphElementPropertySerializer
    {
        public GenericGraphElementPropertySerializer()
            : base(typeof(T))
        { }

    }

    public class GenericGraphElementPropertySerializer : GraphElementPropertySerializer
    {
        public GenericGraphElementPropertySerializer(Type propType)
            : base(pi =>
            {
                return pi.PropertyType == propType;
            },
            obj =>
            {
                return new Dictionary<string, string>()
                {
                    { "", JsonConvert.SerializeObject(obj) }
                };
            },
            type =>
            {
                return type == propType;
            },
            token =>
            {
                return JsonConvert.DeserializeObject(token[0]["value"].ToString(), propType) ?? new object();
            })
        { }
    }
}
