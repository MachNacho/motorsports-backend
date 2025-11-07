using Microsoft.Extensions.Logging;
using motorsports_Domain.Exceptions;
using motorsports_Domain.Interfaces;
using motorsports_Service.DTOs.RaceTrack;
using motorsports_Service.Interface;
using motorsports_Service.Utils;

namespace motorsports_Service.Services
{
    public class RaceTrackService : IRaceTrackService
    {
        private readonly IRaceTrackRepository _trackRepository;
        private readonly ICacheIntegration _cacheIntegration;
        private readonly ILogger<RaceTrackService> _logger;
        public RaceTrackService(IRaceTrackRepository trackRepository, ILogger<RaceTrackService> logger, ICacheIntegration cacheIntegration)
        {
            _logger = logger;
            _trackRepository = trackRepository;
            _cacheIntegration = cacheIntegration;
        }
        public async Task<IReadOnlyCollection<TrackDTO>> GetAllRaceTrack()
        {
            var trackList = await _trackRepository.GetAllRaceTrack();

            List<TrackDTO> trackDTOs = new List<TrackDTO>();
            foreach (var track in trackList)
            {
                trackDTOs.Add(new TrackDTO
                {
                    Id = track.Id,
                    nationName = track.nation.Name,
                    TrackName = track.Circuit,
                    nationCode = track.nation.Code
                });
            }
            return trackDTOs;
        }

        public async Task<FullTrackDTO?> GetRaceTrackById(Guid id)
        {
            var track = await _trackRepository.GetRaceTrackById(id);
            if (track == null)
            {
                throw new RecordNotFound();
            }
            FullTrackDTO FullTrack = new()
            {
                Name = track.Circuit,
                Description = track.Description,
                GrandPrixNames = RaceTrackUtils.ParseGrandPrixNames(track.Grand_Prix_Names),
                Direction = track.Direction.ToString(),
                Type = track.Type.ToString().Replace("_", " "),
                Location = track.Location,
                Length = track.Last_length_used,
                NationName = track.nation.Name,
                NationCode = track.nation.Code,
                imageURL = track.imageUrl
            };
            return FullTrack;
        }
    }
}
