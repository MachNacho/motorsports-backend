using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using motorsports_Domain.Entities;
using motorsports_Service.Contracts;
using motorsports_Service.DTOs.Team;

namespace motorsports_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamServ;
        public TeamController(ITeamService teamServ) { _teamServ = teamServ; }

        [HttpGet]
        public async Task<IActionResult> GetTeams()
        {
            var result = await _teamServ.GetAllTeamsAsync();
            return Ok(result);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddTeam([FromBody] UploadTeamDTO teamToAdd)
        {
            await _teamServ.AddTeamAsync(teamToAdd);
            return NoContent();
        }

        [HttpPatch("Remove/{teamID}")]
        public async Task<IActionResult> RemoveTeam([FromRoute] Guid teamID)
        {
            await _teamServ.DeleteTeamAsync(teamID);
            return NoContent();
        }

        [HttpPatch("Update/{teamID}")]
        public async Task<IActionResult> UpdateTeam([FromRoute] Guid teamID, [FromBody] JsonPatchDocument<TeamEntity> team)
        {
            await _teamServ.UpdateTeamAsync(teamID, team);
            return NoContent();
        }
    }
}
