using System.Text.Json.Serialization;

namespace motorsports_Infrastructure.Seeding.Models
{
    public class NationalitySeedDto
    {
        [JsonPropertyName("capital")]
        public string Capital { get; set; }

        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("continent")]
        public string Continent { get; set; }

        [JsonPropertyName("flag_1x1")]
        public string FlagOneByOne { get; set; }

        [JsonPropertyName("flag_4x3")]
        public string FlagFourByThree { get; set; }

        [JsonPropertyName("iso")]
        public bool IsIso { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
