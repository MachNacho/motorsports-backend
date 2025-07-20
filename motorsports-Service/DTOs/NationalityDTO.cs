using motorsports_Domain.enums;

namespace motorsports_Service.DTOs
{
    public class NationalityDTO
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public ContinentEnum Continent { get; set; }
        public string? FlagUrl { get; set; }
    }
}
