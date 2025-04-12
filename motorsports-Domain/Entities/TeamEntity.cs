using motorsports_Domain.Entities.@base;
using motorsports_Domain.enums;

namespace motorsports_Domain.Entities
{
    public class TeamEntity : BaseEntity
    {
        public string Name { get; set; }
        public NationalityEnums Country { get; set; }
        public int YearFounded { get; set; }
        public string Headquarters { get; set; }
        public  List<DriverEntity> Drivers { get; set; } = new List<DriverEntity>();//List of drivers signed by team
    }
}