namespace motorsports_Service.DTOs.Driver
{
    public class FullDriverDTO
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateOnly BirthDate { get; set; }
        public string? Nationality { get; set; }
        public string? Code { get; set; }
        public string? FlagOneByOne { get; set; }
        public string? FlagFourByThree { get; set; }
        public string Gender { get; set; }
        public int? RaceNumber { get; set; }
        public string? TeamName { get; set; }
        public Guid? TeamId { get; set; }
    }
}
