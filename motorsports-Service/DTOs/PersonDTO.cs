namespace motorsports_Service.DTOs
{
    public class PersonDTO
    {
        public Guid ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly BirthDate { get; set; }
        public string Nationality { get; set; }
        public string Gender { get; set; }
        public string role { get; set; }
        public int RaceNumber { get; set; }
    }
}
