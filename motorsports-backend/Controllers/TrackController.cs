using Microsoft.AspNetCore.Mvc;
using motorsports_Service.DTOs.RaceTrack;
using motorsports_Service.Interface;

namespace motorsports_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackController : ControllerBase
    {
        private readonly IRaceTrackService _trackService;
        private readonly ILogger<TrackController> _logger;
        public TrackController(IRaceTrackService trackService, ILogger<TrackController> logger)
        {
            _trackService = trackService;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IReadOnlyCollection<TrackDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllTracks()
        {
            var tracks = await _trackService.GetAllRaceTrack();
            return Ok(tracks);
        }
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(FullTrackDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTrackById([FromRoute] Guid id)
        {
            if (id == Guid.Empty)
            {
                _logger.LogWarning("GetTrackById called with empty GUID");
                return BadRequest("No track Id provided");
            }

            var tracks = await _trackService.GetRaceTrackById(id);
            return Ok(tracks);
        }
    }
}
