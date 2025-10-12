using System.ComponentModel.DataAnnotations;
using static motorsports_Domain.Constants.Constants;

namespace motorsports_Service.DTOs.Driver
{
    public class UpdateDriverDTO
    {
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public DateOnly? BirthDate { get; set; }

        [Range(1, 99, ErrorMessage = "Race number must be between 1 and 99.")]
        public int? RaceNumber { get; set; }
        public GenderEnum? Gender { get; set; }

        public Guid? NationalityId { get; set; }
        public Guid? TeamId { get; set; }
    }
}
