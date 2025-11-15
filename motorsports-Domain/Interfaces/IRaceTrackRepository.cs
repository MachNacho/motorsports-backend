using motorsports_Domain.Entities;

namespace motorsports_Domain.Interfaces
{
    public interface IRaceTrackRepository
    {
        Task<IReadOnlyCollection<RaceTrackEntity>> GetAllRaceTrack();
        Task<RaceTrackEntity?> GetRaceTrackById(Guid id);
    }
}
