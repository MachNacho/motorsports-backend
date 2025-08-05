using Microsoft.AspNetCore.JsonPatch;
using motorsports_Domain.Entities;

namespace motorsports_Domain.Contracts
{
    public interface ITeamRepository
    {
        Task<IEnumerable<TeamEntity>> GetAllTeams();
        Task<TeamEntity> GetTeamById(Guid id);
        Task CreateTeam(TeamEntity team);
        Task UpdateTeam(Guid id, JsonPatchDocument<TeamEntity> team);
        Task DeleteTeam(Guid id);
    }
}
