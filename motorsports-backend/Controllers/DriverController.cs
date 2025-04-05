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
        private readonly IDriverService _driverService;
        public DriverController(IDriverService driverService)
        {
            _driverService = driverService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDrivers()
        {
            Console.WriteLine("In controller");
            return Ok(await _driverService.GetAllDrivers());
        }
        [HttpPost]
        public async Task<IActionResult> CreateDriver(DriverDTO driver)
        {
            return Ok(await _driverService.CreateDriver(driver));
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> HideDriver(int id, [FromBody] JsonPatchDocument<DriverEntity> driverDoc)
        {
            if (driverDoc == null) { return BadRequest("Invalid patch document"); }
            Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(driverDoc));
            return Ok(await _driverService.UpdateDriver(id, driverDoc));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDriverById(int id)
        {
            return Ok(await _driverService.GetDriverById(id));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDriverfromDB(int id)
        {
            return Ok(_driverService.DeleteDriver(id));
        }
    }
}
