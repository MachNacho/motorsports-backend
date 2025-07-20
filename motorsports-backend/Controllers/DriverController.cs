using Microsoft.AspNetCore.Mvc;
using motorsports_Service.Contracts;
using motorsports_Service.DTOs.Driver;

namespace motorsports_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IDriverService _personService;
        public DriverController(IDriverService personService)
        {
            _personService = personService;
        }

        [HttpGet("list/drivers")]
        public async Task<IActionResult> GetAllDrivers()
        {
            var drivers = await _personService.GetAllDrivers();
            return Ok(drivers);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddPerson(UploadDriverDTO uploadPersonDTO)
        {
            return Ok(await _personService.CreateDriver(uploadPersonDTO));
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDriverProfile(Guid id)
        {
            var updatedDriver = await _personService.GetDriverById(id);
            return Ok(updatedDriver);
        }
        
        [HttpPatch("delete/{personid}")]
        public async Task<IActionResult> DeleteDriver([FromRoute] Guid personid)
        {
            await _personService.DeleteDriver(personid);
            return NoContent();
        }
    }
}
