using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Invoice.Infrastructure.JsonResolver
{
    public class PrivateSetterContractResolver : CamelCasePropertyNamesContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo memberInfo, MemberSerialization memberSerialization)
        {
            var jsonProperty = base.CreateProperty(memberInfo, memberSerialization);

            if (!jsonProperty.Writable)
            {
                if (memberInfo is PropertyInfo propertyInfo)
                {
                    jsonProperty.Writable = propertyInfo.GetSetMethod(true) != null;
                }
            }

            return jsonProperty;
        }
    }
}