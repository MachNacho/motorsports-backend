using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using motorsports_Domain.enums;

namespace motorsports_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnumController : ControllerBase
    {
        // This contorller returns the enum values for the frontend. Allowing me to update options on the frontend from the backend. No DB needed
        [HttpGet("nationalities")]
        public IActionResult GetNationalities()
        {
            var nationalities = Enum.GetValues(typeof(NationalityEnums))
                .Cast<NationalityEnums>()
                .Select(n => new { Name = n.ToString().Replace("_", " ") })
                .ToList();

            return Ok(nationalities);
        }
        [HttpGet("genders")]
        public IActionResult GetGender()
        {
            var gender = Enum.GetValues(typeof(GenderEnums)).Cast<GenderEnums>().Select(g => new {Name = g.ToString() }).ToList();
            return Ok(gender);
        }
        [HttpGet("StaffRoles")]
        public IActionResult GetStaffRole()
        {
            var StaffRole = Enum.GetValues(typeof(StaffRoleEnum)).Cast<StaffRoleEnum>().Select(s => new { Name = s.ToString().Replace("_", " ") }).ToList();
            return Ok(StaffRole);
        }
    }
}
