using Microsoft.AspNetCore.JsonPatch;
using motorsports_Domain.Entities;
using motorsports_Service.DTOs.Team;

namespace motorsports_Service.Contracts
{
    public interface ITeamService
    {
        Task<IEnumerable<TeamDTO>> GetAllTeamsAsync();
        Task<TeamDTO> GetTeamByIdAsync(Guid id);
        Task AddTeamAsync(UploadTeamDTO team);
        Task UpdateTeamAsync(Guid id, JsonPatchDocument<TeamEntity> team);
        Task DeleteTeamAsync(Guid id);
    }
}
