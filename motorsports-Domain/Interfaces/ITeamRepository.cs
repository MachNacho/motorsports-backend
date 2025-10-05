using motorsports_Domain.Entities;

namespace motorsports_Domain.Interfaces
{
    public interface ITeamRepository
    {
        /// <summary>
        /// Retrieves all teams from the data source.
        /// </summary>
        Task<IReadOnlyCollection<TeamEntity>> GetAllTeamsAsync();

        /// <summary>
        /// Retrieves a single team by ID. Returns null if not found.
        /// </summary>
        Task<TeamEntity?> GetTeamByIdAsync(Guid id);

        /// <summary>
        /// Creates a new team entry and returns the persisted entity.
        /// </summary>
        Task<TeamEntity> CreateTeamAsync(TeamEntity team);

        /// <summary>
        /// Updates an existing team record.
        /// </summary>
        Task UpdateTeamAsync(TeamEntity team);

        /// <summary>
        /// Deletes a team by its ID.
        /// </summary>
        Task DeleteTeamAsync(Guid id);
    }
}
