namespace motorsports_Service.DTOs.Driver
{
    public class FullTableDriver
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string? MiddleName { get; set; }
        public string Lastname { get; set; }
        public DateOnly BirthDate { get; set; }
        public required Guid NationalityId { get; set; }
        public string? ImageURL { get; set; }
        public string Gender { get; set; }
        public string? RaceNumber { get; set; }
        public Guid? TeamId { get; set; }
    }
}
