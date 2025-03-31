using motorsports_Domain.Entities.@base;
using motorsports_Domain.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace motorsports_Domain.Entities.@base
{
    public class basePerson : baseEntity
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateOnly birthDate { get; set; }
        public nationalityEnums nationality { get; set; }
        public genderEnums gender { get; set; }
    }
}
