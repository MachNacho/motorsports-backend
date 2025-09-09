using Microsoft.AspNetCore.JsonPatch;
using motorsports_Domain.Contracts;
using motorsports_Domain.Entities;
using motorsports_Service.Contracts;
using motorsports_Service.DTOs.Team;

namespace motorsports_Service.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepo;
        public TeamService(ITeamRepository teamRepo)
        {
            _teamRepo = teamRepo;
        }

        public async Task CreateTeam(UploadTeamDTO team)
        {
            var teamToCreate = new TeamEntity
            {
                NationalityID = team.NationalityID,
                TeamName = team.TeamName,
                YearFounded = team.YearFounded,
            };

            await _teamRepo.CreateTeam(teamToCreate);
        }

        public async Task DeleteTeam(Guid id)
        {
            await _teamRepo.DeleteTeam(id);
        }

        public Task<bool> DeleteTeam(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TeamDTO>> GetAllTeams()
        {
            var a = await _teamRepo.GetAllTeams();
            return a.Select(x => new TeamDTO
            {
                ID = x.ID,
                Name = x.TeamName,
                Headquarters = "",
                YearFounded = DateOnly.FromDateTime(DateTime.Today),
                Country = x.Nationality.Name
            });
            throw new NotImplementedException();
        }

        public Task<TeamEntity> GetTeamById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TeamEntity> UpdateTeam(int id, JsonPatchDocument<TeamEntity> team)
        {
            throw new NotImplementedException();
        }
    }
}
