using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using motorsports_Domain.Contracts;
using motorsports_Domain.Entities;
using motorsports_Domain.Exceptions;
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

        public async Task AddTeamAsync(TeamEntity team)
        {
            try
            {
                await _context.Team.AddAsync(team);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                _logger.LogError("Function:{name} => There was an issue creating a team", nameof(AddTeamAsync));
                throw;
            }
        }

        public async Task RemoveTeamByIdAsync(Guid id)
        {
            try
            {
                var teamToDelete = await _context.Driver.FindAsync(id) ?? throw new NotFoundException($"Team with ID:'{id}' not found");
                teamToDelete.IsActive = false;
                await _context.SaveChangesAsync();
            }
            catch (NotFoundException)
            {
                _logger.LogError("Function:{name} => Couldnt find a team with id:{id}", nameof(RemoveTeamByIdAsync), id);
                throw;
            }
            catch (Exception)
            {
                _logger.LogCritical("Function:{name} => There was an issue removing a team with id:{id}", nameof(RemoveTeamByIdAsync), id);
                throw;
            }
        }

        public async Task<IEnumerable<TeamEntity>> GetAllTeamsAsync()
        {
            try
            {
                var teams = await _context.Team.Where(d => d.IsActive).Include(x => x.Nationality).AsNoTracking().ToListAsync();
                return teams.Count == 0 ? throw new EmptyOrNoRecordsException("No teams found") : teams;
            }
            catch (EmptyOrNoRecordsException)
            {
                _logger.LogError("Function:{name} => There are no active teams in the database", nameof(GetAllTeamsAsync));
                throw;
            }
            catch (Exception)
            {
                _logger.LogCritical("Function:{name} => There was an issue retrieving all teams in the database", nameof(GetAllTeamsAsync));
                throw;
            }
        }

        public async Task<TeamEntity> GetTeamByIdAsync(Guid id)
        {
            try
            {
                var team = await _context.Team.FindAsync(id) ?? throw new NotFoundException($"Team with ID '{id}' not found");
                return team;
            }
            catch (NotFoundException)
            {
                _logger.LogError("Function:{name} => There are no teams with ID: '{id}' in the database", nameof(GetTeamByIdAsync), id);
                throw;
            }
            catch (Exception)
            {
                _logger.LogCritical("Function:{name} => There was an issue retrieving a team in the database", nameof(GetTeamByIdAsync));
                throw;
            }
        }

        public async Task UpdateTeamAsync(Guid id, JsonPatchDocument<TeamEntity> teamPatchDoc)
        {
            try
            {
                var teamToUpdate = await _context.Team.FindAsync(id) ?? throw new NotFoundException($"Team with ID '{id}' not found"); ;
                teamPatchDoc.ApplyTo(teamToUpdate);
                await _context.SaveChangesAsync();
            }
            catch (NotFoundException)
            {
                _logger.LogError("Function:{name} => There are no teams with ID: '{id}' in the database", nameof(UpdateTeamAsync), id);
            }
            catch (Exception)
            {
                _logger.LogCritical("Function:{name} => There was an issue updating a team in the database", nameof(UpdateTeamAsync));
                throw;
            }
        }
    }
}
