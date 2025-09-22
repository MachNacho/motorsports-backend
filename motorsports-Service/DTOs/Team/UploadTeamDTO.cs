using System.ComponentModel.DataAnnotations;

namespace motorsports_Service.DTOs.Team
{
    public class UploadTeamDTO
    {
        [Required]
        public string TeamName { get; set; }
        [Required]
        public DateOnly YearFounded { get; set; }
        [Required]
        public Guid NationalityID { get; set; }

        public string Headquarters { get; set; }
    }
}
