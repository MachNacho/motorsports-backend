using motorsports_Domain.Entities.@base;
using motorsports_Domain.enums;

namespace motorsports_Domain.Entities
{
    public class CircutEntity : BaseEntity
    {
        public string Name { get; set; }
        public int LengthOfficalLayout { get; set; } // in meters
        public int Capacity { get; set; } // number of spectators
        public NationalityEnums Country { get; set; }
        public DateOnly EstablishedDate { get; set; }
    }
}
