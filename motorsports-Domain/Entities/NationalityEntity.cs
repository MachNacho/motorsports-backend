using motorsports_Domain.Entities.@base;
using System.ComponentModel.DataAnnotations;
using static motorsports_Domain.Constants.Constants;

namespace motorsports_Domain.Entities
{
    public class NationalityEntity : BaseEntity
    {
        [Required]
        public required string Name { get; set; }
        [Required]
        public required string Code { get; set; }
        [Required]
        public required ContinentEnum Continent { get; set; }

        //Additional info
        public string? FlagUrl { get; set; }

        //Navigation property
        public ICollection<DriverEntity> Driver { get; set; } = new List<DriverEntity>();
        public ICollection<TeamEntity> Teams { get; set; } = new List<TeamEntity>();
    }
}
