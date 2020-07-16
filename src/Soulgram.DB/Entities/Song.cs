using Newtonsoft.Json;

namespace Soulgram.DB.Entities
{
    public class Song : EntityBase
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
