using motorsports_Domain.Entities.@base;

namespace motorsports_Domain.Entities
{
    public class TeamEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public int YearFounded { get; set; }
        public string Headquarters { get; set; }
    }
}