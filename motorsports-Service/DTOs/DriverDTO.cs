namespace motorsports_Service.DTOs
{
    public class DriverDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly BirthDate { get; set; }
        public string Nationality { get; set; }
        public string Gender { get; set; }
    }
}
