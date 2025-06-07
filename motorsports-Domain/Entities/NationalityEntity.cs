using motorsports_Domain.Entities.@base;
using motorsports_Domain.enums;
using System.ComponentModel.DataAnnotations;

namespace motorsports_Domain.Entities
{
    public class NationalityEntity:BaseEntity
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
        public ICollection<DriverEntity> persons { get; set; } = new List<DriverEntity>();
        public ICollection<TeamEntity> teams { get; set; } = new List<TeamEntity>();
    }
}
