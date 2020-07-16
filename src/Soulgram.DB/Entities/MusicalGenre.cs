using Newtonsoft.Json;

namespace Soulgram.DB.Entities
{
    public class MusicalGenre : EntityBase
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
