using motorsports_Domain.Entities.@base;
using System.ComponentModel.DataAnnotations;

namespace motorsports_Domain.Entities
{
    public class TeamEntity : BaseEntity
    {
        //Team info
        [Required]
        public required string TeamName { get; set; }
        public DateOnly? YearFounded { get; set; }


        //Aditional info
        //Nation
        [Required]
        public required Guid NationalityID { get; set; }
        public NationalityEntity? Nationality { get; set; }

        //List of drivers signed by team
        public ICollection<DriverEntity> Drivers { get; set; } = new List<DriverEntity>();
    }
}