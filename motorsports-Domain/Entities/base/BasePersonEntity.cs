using motorsports_Domain.enums;
using System.ComponentModel.DataAnnotations;

namespace motorsports_Domain.Entities.@base
{
    public class BasePersonEntity : BaseEntity
    {
        [Required]
        public required string FirstName { get; set; }
        public string? MiddleName { get; set; } // Optional, no [Required]
        [Required]
        public required string LastName { get; set; }
        [Required]
        public required DateOnly BirthDate { get; set; }
        [Required]
        public required string NationalityID { get; set; }
        public required NationalityEntity Nationality { get; set; }
        [Required]
        public required GenderEnums Gender { get; set; }
    }
}
