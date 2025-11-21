namespace motorsports_Service.DTOs.Driver
{
    public class FullDriverDTO
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string? MiddleName { get; set; }
        public string Lastname { get; set; }
        public string? Description { get; set; }
        public DateOnly BirthDate { get; set; }
        public string? Nationality { get; set; }
        public string? Code { get; set; }
        public string? Colour { get; set; }
        public string? ImageURL { get; set; }
        public string? FlagOneByOne { get; set; }
        public string? FlagFourByThree { get; set; }
        public string Gender { get; set; }
        public int? RaceNumber { get; set; }
        public string? TeamName { get; set; }
        public Guid? TeamId { get; set; }
        public int RacesParticipated { get; set; }
        public int RacePodiums { get; set; }
        public int RaceWins { get; set; }
        public int ChampionshipTitles { get; set; }
        public int RacePole { get; set; }
        public int CareerPoints { get; set; }
        public int RaceLapsLed { get; set; }
    }
}
