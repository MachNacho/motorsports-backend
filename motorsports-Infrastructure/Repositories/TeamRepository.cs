using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using motorsports_Domain.Contracts;
using motorsports_Domain.Entities;
using motorsports_Domain.Exceptions;
using motorsports_Infrastructure.Data;

namespace motorsports_Infrastructure.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly ApplicationDBContext _context;
        public TeamRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateTeam(TeamEntity team)
        {
            try
            {
                await _context.Team.AddAsync(team);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public async Task<bool> DeleteTeam(int id)
        {
            try
            {
                var teamToDelete = await GetTeamById(id);
                if (teamToDelete != null)
                {
                    _context.Remove(teamToDelete);
                    await _context.SaveChangesAsync();
                    return true;
                }
                throw new NotFoundException("Driver not found");

            }
            catch (NotFoundException ex)
            {
                throw new NotFoundException($"Driver not found {ex}");
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public async Task<IEnumerable<TeamEntity>> GetAllTeams()
        {
            try
            {
                var teams = await _context.Team.AsNoTracking().Where(d => d.IsActive).ToListAsync();
                return teams.Count == 0 ? throw new EmptyOrNoRecordsException("No teams found") : teams;
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public async Task<TeamEntity> GetTeamById(int id)
        {
            try
            {
                var team = await _context.Team.FindAsync(id);
                return team;
            }
            catch (Exception)
            {
                throw new NotFoundException($"Team with ID {id} not found");
            }
        }

        public async Task<TeamEntity> UpdateTeam(int id, JsonPatchDocument<TeamEntity> team)
        {
            try
            {
                var OGmodel = await GetTeamById(id);
                team.ApplyTo(OGmodel);
                await _context.SaveChangesAsync();
                return OGmodel;
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }
    }
}
