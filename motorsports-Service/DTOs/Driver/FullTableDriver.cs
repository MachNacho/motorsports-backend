namespace motorsports_Service.DTOs.Driver
{
    public class FullTableDriver
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string? MiddleName { get; set; }
        public string Lastname { get; set; }
        public DateOnly BirthDate { get; set; }
        public required Guid NationalityId { get; set; }
        public string NationName { get; set; }
        public string? Description { get; set; }
        public string? Nationailty { get; set; }
        public string Gender { get; set; }
        public string? RaceNumber { get; set; }
        public Guid? TeamId { get; set; }
        public string? TeamName { get; set; }
        public int? RacesParticipated { get; set; }
        public int? RacePodiums { get; set; }
        public int? RaceWins { get; set; }
        public int? ChampionshipTitles { get; set; }
        public int? RacePole { get; set; }
        public int? CareerPoints { get; set; }
        public int? RaceLapsLed { get; set; }
    }
}
