using Microsoft.AspNetCore.Mvc;
using motorsports_Service.DTOs.Nationality;
using motorsports_Service.Interface;

namespace motorsports_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationalityController : ControllerBase
    {
        private readonly INationalityService _nationService;

        public NationalityController(INationalityService nationService)
        {
            _nationService = nationService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IReadOnlyCollection<NationalityDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAllNations()
        {
            var nations = await _nationService.GetAllNations();
            return Ok(nations);
        }

        [HttpGet("stats")]
        [ProducesResponseType(typeof(IReadOnlyCollection<NationStatsDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetStats()
        {
            var results = await _nationService.GetStatsAsync();
            return Ok(results);
        }
    }
}
