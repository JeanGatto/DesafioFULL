using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Reflection;

namespace Desafio.Web.Models
{
    public static class JsonExtensions
    {
        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            Formatting = Formatting.None,
            NullValueHandling = NullValueHandling.Ignore,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            ContractResolver = new PrivateResolver { NamingStrategy = new CamelCaseNamingStrategy() }
        };

        public static T FromJson<T>(this string value)
        {
            return JsonConvert.DeserializeObject<T>(value, Settings);
        }

        public static string ToJson<T>(this T value)
        {
            return JsonConvert.SerializeObject(value, Settings);
        }

        internal class PrivateResolver : DefaultContractResolver
        {
            protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
            {
                var prop = base.CreateProperty(member, memberSerialization);
                if (!prop.Writable)
                {
                    var property = member as PropertyInfo;
                    prop.Writable = property?.GetSetMethod(true) != null;
                }
                return prop;
            }
        }
    }
}
