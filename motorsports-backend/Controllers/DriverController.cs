using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using motorsports_Service.Contracts;

namespace motorsports_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IDriverService _driverService;
        public DriverController(IDriverService driverService) { _driverService = driverService; }
        [HttpGet]
        public async Task<IActionResult> GetAllDrivers()
        {
            Console.WriteLine("In controller");
            return Ok(await _driverService.GetAllDrivers());
        }
    }
}
