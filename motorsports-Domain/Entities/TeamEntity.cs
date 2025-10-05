using motorsports_Domain.Entities.@base;
using System.ComponentModel.DataAnnotations;

namespace motorsports_Domain.Entities
{
    public class TeamEntity : BaseEntity
    {
        [MaxLength(100)]
        public required string TeamName { get; set; }
        public DateOnly? FoundedDate { get; set; }

        [MaxLength(100)]
        public required string Headquarters { get; set; }

        //Foreign Keys
        public required Guid NationalityId { get; set; }
        public required NationalityEntity Nationality { get; set; }

        public ICollection<DriverEntity> Drivers { get; set; } = new List<DriverEntity>();
    }
}