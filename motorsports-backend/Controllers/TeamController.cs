using Microsoft.AspNetCore.Mvc;
using motorsports_Domain.Entities;
using motorsports_Service.DTOs.Team;
using motorsports_Service.Interface;

namespace motorsports_backend.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;
        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IReadOnlyCollection<TeamDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllTeams()
        {
            var teamListResult = await _teamService.GetAllTeamAsync();
            return Ok(teamListResult);
        }

        [HttpGet("team/{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTeamById([FromRoute] Guid id)
        {
            var teamResult = await _teamService.GetTeamByIdAsync(id);
            return Ok(teamResult);
        }

        [HttpPut("update/{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> UpdateTeam([FromRoute] Guid id, [FromBody] TeamEntity test)
        {
            await _teamService.UpdateTeamAsync(id, test);
            return NoContent();
        }

        [HttpDelete("delete/{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteTeam([FromRoute] Guid id)
        {
            await _teamService.DeleteTeamAsync(id);
            return NoContent();
        }

        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateTeam([FromBody] TeamEntity entity)
        {
            await _teamService.CreateTeamAsync(entity);
            return Created();
        }
    }
}
