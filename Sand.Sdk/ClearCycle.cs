using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Sand.Sdk
{

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ClearCycle
    {
        [EnumMember(Value = "0")]
        T1,
        [EnumMember(Value = "1")]
        T0,
        [EnumMember(Value = "2")]
        D0
    }
}
