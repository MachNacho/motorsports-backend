namespace motorsports_Service.DTOs.RaceTrack
{
    public class FullTrackDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> GrandPrixNames { get; set; } = new();
        public string Direction { get; set; }
        public string Type { get; set; }
        public string Location { get; set; }
        public string Length { get; set; }
        public string Turns { get; set; }
        public string NationName { get; set; }
        public string NationCode { get; set; }
        public string imageURL { get; set; }
    }
}
