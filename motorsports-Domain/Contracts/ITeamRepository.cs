using Microsoft.AspNetCore.JsonPatch;
using motorsports_Domain.Entities;

namespace motorsports_Domain.Contracts
{
    public interface ITeamRepository
    {
        Task<IEnumerable<TeamEntity>> GetAllTeamsAsync();
        Task<TeamEntity> GetTeamByIdAsync(Guid id);
        Task AddTeamAsync(TeamEntity team);
        Task UpdateTeamAsync(Guid id, JsonPatchDocument<TeamEntity> team);
        Task RemoveTeamByIdAsync(Guid id);
    }
}
