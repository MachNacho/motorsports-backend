using Microsoft.AspNetCore.JsonPatch;
using motorsports_Domain.Entities;

namespace motorsports_Domain.Contracts
{
    public interface ITeamRepository
    {
        Task<IEnumerable<TeamEntity>> GetAllTeams();
        Task<TeamEntity> GetTeamById(int id);
        Task<bool> CreateTeam(TeamEntity team);
        Task<TeamEntity> UpdateTeam(int id, JsonPatchDocument<TeamEntity> team);
        Task<bool> DeleteTeam(int id);
    }
}
