namespace motorsports_Service.DTOs.Team
{
    public class TeamDTO
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public int driverCount { get; set; } = 0;
        public string? imageURL { get; set; }
        public string? Colour { get; set; }
        public DateOnly YearFounded { get; set; }
    }
}
