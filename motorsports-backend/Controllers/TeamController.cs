using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using motorsports_Service.Contracts;

namespace motorsports_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;
        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTeams()
        {
            return Ok(await _teamService.GetAllTeams());
        }
    }
}
