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

        public async Task CreateTeam(TeamEntity team)
        {
            try
            {
                await _context.Team.AddAsync(team);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                _logger.LogError("Function:{name} => There was an issue creating a team", nameof(CreateTeam));
                throw;
            }
        }

        public async Task DeleteTeam(Guid id)
        {
            try
            {
                var teamToDelete = await _context.Driver.FindAsync(id) ?? throw new NotFoundException($"Driver with ID:'{id}' not found");
                teamToDelete.IsActive = false;
                await _context.SaveChangesAsync();
            }
            catch (NotFoundException ex)
            {
                _logger.LogError("Function:{name} => Couldnt find a team with id:{id}", nameof(DeleteTeam), id);
                throw new NotFoundException($"Driver {id} not found: {ex}");
            }
            catch (Exception)
            {
                _logger.LogCritical("Function:{name} => There was an issue deleting a team with id:{id}", nameof(DeleteTeam), id);
                throw;
            }
        }

        public async Task<IEnumerable<TeamEntity>> GetAllTeams()
        {
            try
            {
                var teams = await _context.Team.AsNoTracking().Where(d => d.IsActive).ToListAsync();
                return teams.Count == 0 ? throw new EmptyOrNoRecordsException("No teams found") : teams;
            }
            catch (EmptyOrNoRecordsException)
            {
                _logger.LogError("Function:{name} => There are no active teams in the database", nameof(GetAllTeams));
                throw;
            }
            catch (Exception)
            {
                _logger.LogCritical("Function:{name} => There was an issue retrieving all teams in the database", nameof(GetAllTeams));
                throw;
            }
        }

        public async Task<TeamEntity> GetTeamById(Guid id)
        {
            try
            {
                var team = await _context.Team.FindAsync(id) ?? throw new NotFoundException($"Team with ID '{id}' not found");
                return team;
            }
            catch (NotFoundException)
            {
                _logger.LogError("Function:{name} => There are no teams with ID: '{id}' in the database", nameof(GetTeamById),id);
                throw;
            }
            catch (Exception)
            {
                _logger.LogCritical("Function:{name} => There was an issue retrieving a team in the database", nameof(GetTeamById));
                throw;
            }
        }

        public async Task UpdateTeam(Guid id, JsonPatchDocument<TeamEntity> teamPatchDoc)
        {
            try
            {
                var teamToUpdate = await _context.Team.FindAsync(id) ?? throw new NotFoundException($"Team with ID '{id}' not found"); ;
                teamPatchDoc.ApplyTo(teamToUpdate);
                await _context.SaveChangesAsync();
            }
            catch (NotFoundException)
            {
                _logger.LogError("Function:{name} => There are no teams with ID: '{id}' in the database", nameof(UpdateTeam), id);
            }
            catch (Exception)
            {
                _logger.LogCritical("Function:{name} => There was an issue updating a team in the database", nameof(UpdateTeam));
                throw;
            }
        }
    }
}
