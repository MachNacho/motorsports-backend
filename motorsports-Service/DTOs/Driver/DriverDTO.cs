namespace motorsports_Service.DTOs.Driver
{
    public class DriverDTO
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string? Code { get; set; }
        public string? FlagOneByOne { get; set; }
        public int? RaceNumber { get; set; }
        public string? TeamName { get; set; }
    }
}
