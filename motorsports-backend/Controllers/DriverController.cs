using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using motorsports_Domain.Entities;
using motorsports_Service.Contracts;
using motorsports_Service.DTOs;

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
        public async Task<IActionResult> AddPerson(UploadPersonDTO uploadPersonDTO)
        {
            return Ok(await _personService.CreateDriver(uploadPersonDTO));
        }

        [HttpPatch("update/{personid}")]
        public async Task<IActionResult> UpdateDriver(Guid personid, [FromBody] JsonPatchDocument<DriverEntity> driver)
        {
            if (driver == null)
            {
                return BadRequest("Driver data is null");
            }
            var updatedDriver = await _personService.UpdateDriver(personid, driver);
            return Ok(updatedDriver);
        }
        [HttpDelete("delete/{personid}")]
        public async Task<IActionResult> DeleteDriver(Guid personid)
        {
            await _personService.DeleteDriver(personid);          
            return Ok("Driver deleted successfully");         
        }
    }
}
