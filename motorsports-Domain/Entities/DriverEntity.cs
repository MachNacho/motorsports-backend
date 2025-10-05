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

        //Foreign Keys
        public required Guid NationalityId { get; set; }
        public required NationalityEntity Nationality { get; set; }

        public Guid? TeamId { get; set; }
        public TeamEntity? Team { get; set; }

    }
}
