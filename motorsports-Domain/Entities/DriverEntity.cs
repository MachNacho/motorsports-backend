using motorsports_Domain.Entities.@base;

namespace motorsports_Domain.Entities
{
    public class DriverEntity : BasePersonEntity
    {
        public int RaceNumber { get; set; }
        //Linking drivers to teams
        // This is a foreign key to the TeamEntity
       // public int TeamID { get; set; }
        //public TeamEntity Team { get; set; }
    }
}
