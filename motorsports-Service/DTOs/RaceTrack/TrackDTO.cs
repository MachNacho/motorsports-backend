namespace motorsports_Service.DTOs.RaceTrack
{
    public class TrackDTO
    {
        public Guid Id { get; set; }
        public string TrackName { get; set; }
        public string Location { get; set; }
        public string nationCode { get; set; }
        public string nationName { get; set; }
    }
}
