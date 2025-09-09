using Microsoft.AspNetCore.JsonPatch;
using motorsports_Domain.Entities;
using motorsports_Service.DTOs.Team;

namespace motorsports_Service.Contracts
{
    public interface ITeamService
    {
        Task<IEnumerable<TeamDTO>> GetAllTeams();
        Task<TeamEntity> GetTeamById(int id);
        Task CreateTeam(UploadTeamDTO team);
        Task<TeamEntity> UpdateTeam(int id, JsonPatchDocument<TeamEntity> team);
        Task<bool> DeleteTeam(int id);
    }
}
