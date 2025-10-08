using System.ComponentModel.DataAnnotations;
using static motorsports_Domain.Constants.Constants;

namespace motorsports_Service.DTOs.Driver
{
    public class UploadDriverDTO
    {
        public Guid Id { get; set; }
        public required string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public required string LastName { get; set; }
        public required DateOnly BirthDate { get; set; }
        public required GenderEnum Gender { get; set; }
        public required Guid NationalityID { get; set; }
        public Guid? TeamID { get; set; }

        [Range(1, 99, ErrorMessage = "Race number must be between 1 and 99.")]
        public int? RaceNumber { get; set; }
    }
}
