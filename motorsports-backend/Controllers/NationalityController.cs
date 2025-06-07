using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using motorsports_Service.Contracts;
using motorsports_Service.DTOs;

namespace motorsports_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationalityController : ControllerBase
    {
        private readonly INationalityService _nationalityService;
        public NationalityController(INationalityService nationalityService)
        {
            _nationalityService = nationalityService;
        }

        [HttpGet("list")]
        public async Task<IActionResult> List() 
        {
            var nationalities = await _nationalityService.GetAllNationalitiesAsync(null);
            return Ok(nationalities);
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddCountry(NationalityDTO nationalityDTO)
        {
            return Ok(await _nationalityService.CreateNationalityAsync(nationalityDTO));
        }
    }
}
