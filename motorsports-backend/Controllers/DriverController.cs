using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using motorsports_Service.DTOs.Driver;
using motorsports_Service.Interface;

namespace motorsports_backend.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    [Produces("application/json")]
    public class DriverController : ControllerBase
    {
        private readonly IDriverService _driverService;
        private readonly ILogger<DriverController> _logger;
        public DriverController(IDriverService driverService, ILogger<DriverController> logger)
        {
            _driverService = driverService;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IReadOnlyCollection<DriverDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllDrivers()
        {
            _logger.LogInformation("Fetching all drivers");
            var drivers = await _driverService.GetAllDriversAsync();
            _logger.LogInformation("Successfully retrieved {DriverCount} drivers", drivers.Count);
            return Ok(drivers);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(FullDriverDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetDriverById([FromRoute] Guid id)
        {
            if (id == Guid.Empty)
            {
                _logger.LogWarning("GetDriverById called with empty GUID");
                return BadRequest("No driver Id provided");
            }

            _logger.LogInformation("Fetching driver with ID: {DriverId}", id);
            var driver = await _driverService.GetDriverByIdAsync(id);

            _logger.LogInformation("Successfully retrieved driver: {DriverId}", id);
            return Ok(driver);
        }

        [HttpPut("{id:guid}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateDriver([FromRoute] Guid id, [FromBody] UpdateDriverDTO updateDriver)
        {
            if (id == Guid.Empty)
            {
                _logger.LogWarning("UpdateDriver called with empty GUID");
                return BadRequest("No driver Id provided");
            }

            _logger.LogInformation("Updating driver with ID: {DriverId}", id);
            await _driverService.UpdateDriverAsync(id, updateDriver);

            _logger.LogInformation("Successfully updated driver: {DriverId}", id);
            return NoContent();
        }

        [HttpPost()]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateDriver([FromBody] UploadDriverDTO uploadDriver)
        {
            _logger.LogInformation("Creating new driver: {DriverName}", uploadDriver.FirstName);

            var createdDriver = await _driverService.CreateDriverAsync(uploadDriver);

            _logger.LogInformation("Successfully created driver with ID: {DriverId}", createdDriver.Id);

            return CreatedAtAction(
                actionName: nameof(GetDriverById),
                routeValues: new { id = createdDriver.Id },
                value: createdDriver);
        }

        [HttpDelete("{id:guid}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteDriver([FromRoute] Guid id)
        {
            // Validate input
            if (id == Guid.Empty)
            {
                _logger.LogWarning("DeleteDriver called with empty GUID");
                return BadRequest("No driver Id provided");
            }

            _logger.LogInformation("Deleting driver with ID: {DriverId}", id);
            await _driverService.DeleteDriverAsync(id);

            _logger.LogInformation("Successfully deleted driver: {DriverId}", id);
            return NoContent();
        }
    }
}
