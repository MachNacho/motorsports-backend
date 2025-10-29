namespace motorsports_Service.DTOs.Team
{
    public class FullTeamDTO
    {
        public string TeamName { get; set; }
        public DateOnly? FoundedDate { get; set; }
        public string Headquarters { get; set; }
        public string nationCode { get; set; }
        public string nationName { get; set; }

        public ICollection<TeamDriver> Drivers { get; set; } = new List<TeamDriver>();

    }
    public class TeamDriver
    {
        public Guid id { get; set; }
        public string Firstname { get; set; }
        public string Lasstname { get; set; }
        public string nationCode { get; set; }
    }
}