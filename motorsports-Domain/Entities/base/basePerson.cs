using motorsports_Domain.enums;

namespace motorsports_Domain.Entities.@base
{
    public class BasePerson : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly BirthDate { get; set; }
        public NationalityEnums Nationality { get; set; }
        public GenderEnums Gender { get; set; }
    }
}
