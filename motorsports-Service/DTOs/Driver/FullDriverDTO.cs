namespace motorsports_Service.DTOs.Driver
{
    public class FullDriverDTO
    {
        public Guid ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly BirthDate { get; set; }
        public string Gender { get; set; }
        public int RaceNumber { get; set; }
        public Guid NationID { get; set; }
        public string NationName { get; set; }
        public string Continent { get; set; }
        public string NationCode { get; set; }
        public Guid? TeamID { get; set; }
        public string TeamnNme { get; set; }
    }
}
