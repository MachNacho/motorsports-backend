using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using motorsports_Domain.Entities;
using motorsports_Domain.Exceptions;
using motorsports_Domain.Interfaces;
using motorsports_Infrastructure.Data;

namespace motorsports_Infrastructure.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly ILogger<TeamRepository> _logger;

        public TeamRepository(ApplicationDBContext context, ILogger<TeamRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<TeamEntity> CreateTeamAsync(TeamEntity team)
        {
            await _context.Team.AddAsync(team);
            await _context.SaveChangesAsync();
            return team;
        }

        public async Task DeleteTeamAsync(Guid id)
        {
            var teamToDelete = await _context.Team.FindAsync(id);
            if (teamToDelete is null)
            {
                _logger.LogWarning("Attempted to delete team with ID {TeamId}, but it was not found.", id);
                throw new RecordNotFound($"Team with ID '{id}' not found");
            }
            teamToDelete.MarkAsDeleted();
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyCollection<TeamEntity>> GetAllTeamsAsync()
        {
            var teams = await _context.Team.Include(x => x.Drivers).AsNoTracking().ToListAsync();
            return teams.AsReadOnly();
        }

        public async Task<TeamEntity?> GetTeamByIdAsync(Guid id)
        {
            var team = await _context.Team.Include(d => d.Drivers).ThenInclude(dn => dn.Nationality).Include(n => n.Nationality).AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
            return team;
        }

        public async Task UpdateTeamAsync(TeamEntity team)
        {
            var existingTeam = await _context.Driver.FindAsync(team.Id);
            if (existingTeam is null)
            {
                _logger.LogWarning("Attempted to update team with ID {TeamId}, but it was not found.", team.Id);
                throw new RecordNotFound($"Team with ID '{team.Id}' not found.");
            }
            _context.Entry(existingTeam).CurrentValues.SetValues(team);
            await _context.SaveChangesAsync();
        }
    }
}
