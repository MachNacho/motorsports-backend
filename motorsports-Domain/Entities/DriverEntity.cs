using motorsports_Domain.Entities.@base;
using System.ComponentModel.DataAnnotations;
using static motorsports_Domain.Constants.Constants;

namespace motorsports_Domain.Entities
{
    public class DriverEntity : BaseEntity
    {
        //Personal info
        public required string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public required string LastName { get; set; }
        public required DateOnly BirthDate { get; set; }
        [Range(1, 99, ErrorMessage = "Race number must be between 1 and 99.")]
        public int? RaceNumber { get; set; }
        public required GenderEnum Gender { get; set; }
        public string? ImageURL { get; set; }
        public string? Description { get; set; }

        //Race stats
        public int RacesParticipated { get; set; } = 0;
        public int RacePodiums { get; set; } = 0;
        public int RaceWins { get; set; } = 0;
        public int ChampionshipTitles { get; set; } = 0;
        public int RacePole { get; set; } = 0;
        public int CareerPoints { get; set; } = 0;
        public int RaceLapsLed { get; set; } = 0;

        //Foreign Keys
        public required Guid NationalityId { get; set; }
        public NationalityEntity? Nationality { get; set; }

        public Guid? TeamId { get; set; }
        public TeamEntity? Team { get; set; }

    }
}
