using motorsports_Domain.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace motorsports_Service.DTOs
{
    public class UploadPersonDTO
    {
        public required string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public required string LastName { get; set; }
        public required DateOnly BirthDate { get; set; }
        public required GenderEnum Gender { get; set; }
        public required Guid NationalityID { get; set; }
        public Guid? TeamID { get; set; }
        public string? ImageUrl { get; set; }
        public string? Description { get; set; }
    }
}
