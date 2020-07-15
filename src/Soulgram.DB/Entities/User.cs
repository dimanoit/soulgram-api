using System.Collections.Generic;
using Newtonsoft.Json;

namespace Soulgram.DB.Entities
{
    public class User
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("surname")]
        public string Surname { get; set; }

        [JsonProperty("group")]
        public IList<MusicGroup> LikedGroups { get; set; }

        [JsonProperty("musical_genre")]
        public IList<MusicalGenre> LikedGenres { get; set; }

        [JsonProperty("song")]
        public IList<Song> LikedSongs { get; set; }
    }
}
