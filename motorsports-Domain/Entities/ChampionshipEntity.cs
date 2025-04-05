using motorsports_Domain.Entities.@base;
using motorsports_Domain.enums;

namespace motorsports_Domain.Entities
{
    public class ChampionshipEntity : BaseEntity
    {
        public string Name { get; set; }
        public int YearFounded { get; set; }
        public NationalityEnums Country { get; set; }
        public string Type { get; set; } // e.g. Formula 1, MotoGP, etc.
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
