using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Linq;

namespace Soulgram.Common
{
    public static class Serialization
    {
        public static JsonSerializerSettings JsonSerializerSettings
        {
            get
            {
                var settings = new JsonSerializerSettings();
                UpdateJsonSettings(settings);
                return settings;
            }
        }

        public static void UpdateJsonSettings(JsonSerializerSettings settings)
        {
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            if (!settings.Converters.Any(o => o is StringEnumConverter))
            {
                settings.Converters.Add(new StringEnumConverter());
            }

            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        }
    }
}
