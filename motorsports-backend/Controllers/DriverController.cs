using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using motorsports_Domain.Entities;
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
        public async Task<IActionResult> AddPerson([FromBody] UploadDriverDTO uploadPersonDTO)
        {
            await _personService.CreateDriver(uploadPersonDTO);
            return Created();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDriverProfile([FromRoute] Guid id)
        {
            var updatedDriver = await _personService.GetDriverById(id);
            return Ok(updatedDriver);
        }

        [HttpPatch("delete/{DriverId}")]
        public async Task<IActionResult> DeleteDriver([FromRoute] Guid DriverId)
        {
            await _personService.DeleteDriver(DriverId);
            return NoContent();
        }
        [HttpPatch("Update/{Id}")]
        public async Task<IActionResult> UpdateDriver([FromRoute] Guid Id, [FromBody] JsonPatchDocument<DriverEntity> A)
        {
            await _personService.UpdateDriver(Id, A);
            return NoContent();
        }
    }
}
