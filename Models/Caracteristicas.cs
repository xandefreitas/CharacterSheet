using Newtonsoft.Json;

namespace CharacterSheet.Models
{
    public class Caracteristicas
    {
        [JsonProperty("name")]
        public string Name {get; set; }

        [JsonProperty("age")]
        public string Age {get; set; }

        [JsonProperty("alignment")]
        public string Alignment {get; set; }

        [JsonProperty("size_description")]
        public string Size_description {get; set; }
    }
}