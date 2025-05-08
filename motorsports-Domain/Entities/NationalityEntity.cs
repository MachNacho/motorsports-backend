using motorsports_Domain.Entities.@base;

namespace motorsports_Domain.Entities
{
    public class NationalityEntity:BaseEntity
    {
        public required string Name { get; set; }
        public required string Code { get; set; }
        public string Continent { get; set; }
    }
}
