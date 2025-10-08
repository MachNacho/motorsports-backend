using motorsports_Domain.Entities.@base;
using System.ComponentModel.DataAnnotations;
using static motorsports_Domain.Constants.Constants;

namespace motorsports_Domain.Entities
{
    public class NationalityEntity : BaseEntity
    {
        public string? Capital { get; set; }
        public string? Code { get; set; }
        public ContinentEnum Continent { get; set; }
        public string? FlagOneByOne { get; set; }
        public string? FlagFourByThree { get; set; }
        public bool IsIso { get; set; }
        [MaxLength(100)]
        public string? Name { get; set; }

        //Navigation property
        public ICollection<DriverEntity> Drivers { get; set; } = new List<DriverEntity>();
        public ICollection<TeamEntity> Teams { get; set; } = new List<TeamEntity>();
    }
}
