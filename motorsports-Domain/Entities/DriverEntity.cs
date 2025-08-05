using motorsports_Domain.Entities.@base;
using System.ComponentModel.DataAnnotations;
using static motorsports_Domain.Constants.Constants;

namespace motorsports_Domain.Entities
{
    public class DriverEntity : BaseEntity
    {
        //Personal info
        [Required]
        public required string FirstName { get; set; }
        public string? MiddleName { get; set; }
        [Required]
        public required string LastName { get; set; }
        [Required]
        public required DateOnly BirthDate { get; set; }
        [Required]
        public required GenderEnum Gender { get; set; }

        //Aditional info

        //Race info
        public int? RaceNumber { get; set; }

        //Nation
        [Required]
        public required Guid NationalityID { get; set; }
        public NationalityEntity? Nationality { get; set; }

        //Team
        public Guid? TeamID { get; set; }
        public TeamEntity? Team { get; set; }


        //Other info
        public string? ImageUrl { get; set; }
        public string? Description { get; set; }

    }
}
