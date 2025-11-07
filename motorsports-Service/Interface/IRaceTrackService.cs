using motorsports_Service.DTOs.RaceTrack;

namespace motorsports_Service.Interface
{
    public interface IRaceTrackService
    {
        Task<IReadOnlyCollection<TrackDTO>> GetAllRaceTrack();
        Task<FullTrackDTO?> GetRaceTrackById(Guid id);
    }
}
