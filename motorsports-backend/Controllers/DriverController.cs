using Microsoft.AspNetCore.Mvc;
using motorsports_Service.DTOs.Driver;
using motorsports_Service.Interface;

namespace motorsports_backend.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IDriverService _driverService;
        public DriverController(IDriverService driverService)
        {
            _driverService = driverService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllDrivers()
        {
            var drivers = await _driverService.GetAllDriversAsync();
            return Ok(drivers);
        }

        [HttpGet("driver/{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetDriverById([FromRoute] Guid id)
        {
            var driver = await _driverService.GetDriverByIdAsync(id);
            return Ok(driver);
        }

        [HttpPut("update/{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateDriver([FromRoute] Guid id, [FromBody] UpdateDriverDTO updateDriver)
        {
            await _driverService.UpdateDriverAsync(id, updateDriver);
            return NoContent();
        }

        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> CreateDriver([FromBody] UploadDriverDTO uploadDriver)
        {
            var a = await _driverService.CreateDriverAsync(uploadDriver);
            return CreatedAtAction(nameof(GetDriverById), new { id = a.Id }, a);
        }

        [HttpDelete("delete/{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteDriver([FromRoute] Guid id)
        {
            await _driverService.DeleteDriverAsync(id);
            return NoContent();
        }
    }
}
