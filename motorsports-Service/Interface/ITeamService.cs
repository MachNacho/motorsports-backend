using motorsports_Domain.Entities;
using motorsports_Service.DTOs.Team;

namespace motorsports_Service.Interface
{
    public interface ITeamService
    {
        Task<IReadOnlyCollection<TeamDTO>> GetAllTeamAsync();
        Task<TeamDTO> GetTeamByIdAsync(Guid id);
        Task<TeamEntity> CreateTeamAsync(TeamEntity team);
        Task UpdateTeamAsync(Guid id, TeamEntity team);
        Task DeleteTeamAsync(Guid id);
    }
}
