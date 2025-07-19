using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace motorsports_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        public TeamController() { }

        [HttpGet]
        public async Task<IActionResult> GetTeams([FromQuery] string TeamName)
        {
            throw new NotImplementedException();
        }

        //Edit team details
        //Delete team
    }
}
