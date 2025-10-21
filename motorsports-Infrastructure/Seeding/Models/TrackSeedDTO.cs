using System.Text.Json.Serialization;

namespace motorsports_Infrastructure.Seeding.Models
{
    public class TrackSeedDTO
    {
        [JsonPropertyName("Circuit")]
        public string Circuit { get; set; }


        [JsonPropertyName("Type")]
        public string Type { get; set; }


        [JsonPropertyName("Direction")]
        public string Direction { get; set; }


        [JsonPropertyName("Location")]
        public string Location { get; set; }


        [JsonPropertyName("Country")]
        public string Country { get; set; }


        [JsonPropertyName("Last length used")]
        public string LastLengthUsed { get; set; }


        [JsonPropertyName("Turns")]
        public string Turns { get; set; }


        [JsonPropertyName("Grands Prix")]
        public string GrandsPrix { get; set; }
    }
}
