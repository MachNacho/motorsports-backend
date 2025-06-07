using motorsports_Domain.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
