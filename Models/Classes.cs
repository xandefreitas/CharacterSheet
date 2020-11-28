using System.Collections.Generic;
using Newtonsoft.Json;

namespace CharacterSheet.Models
{
    public class Proficiency
    {
        [JsonProperty("index")]
        public string Index{get; set; }
        
        [JsonProperty("name")]
        public string Name{get; set; }
        
        [JsonProperty("url")]
        public string Url{get; set; }
        
    }
    public class Classes
    {
        [JsonProperty("name")]
        public string Name {get; set; }

        [JsonProperty("hit_die")]
        public int Hit_die {get; set; }

        [JsonProperty("proficiencies")]
        public List<Proficiency> Proficiencies {get; set; }

    }
}