using System.Collections.Generic;
using Newtonsoft.Json;

namespace Soulgram.DB.Entities
{
   public class MusicGroup : EntityBase
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("song")]
        public IList<Song> Songs { get; set; }

        [JsonProperty("musical_genre")]
        public IList<MusicalGenre> Genres { get; set; }
    }
}
