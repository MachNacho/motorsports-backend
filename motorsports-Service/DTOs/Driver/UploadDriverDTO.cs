using static motorsports_Domain.Constants.Constants;

namespace motorsports_Service.DTOs.Driver
{
    public class UploadDriverDTO
    {
        public Guid Id { get; set; }
        public required string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public required string LastName { get; set; }
        public string? Description { get; set; }
        public required DateOnly BirthDate { get; set; }
        public required GenderEnum Gender { get; set; }
        public required Guid NationalityID { get; set; }
        public Guid? TeamID { get; set; }
        public string? RaceNumber { get; set; }
        public string? RacesParticipated { get; set; }
        public string? RacePodiums { get; set; }
        public string? RaceWins { get; set; }
        public string? ChampionshipTitles { get; set; }
        public string? RacePole { get; set; }
        public string? CareerPoints { get; set; }
        public string? RaceLapsLed { get; set; }
    }
}
