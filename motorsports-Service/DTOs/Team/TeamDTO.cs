namespace motorsports_Service.DTOs.Team
{
    public class TeamDTO
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public DateOnly YearFounded { get; set; }
        public string Headquarters { get; set; }
    }
}
