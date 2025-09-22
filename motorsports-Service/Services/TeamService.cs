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

        public async Task AddTeamAsync(UploadTeamDTO team)
        {
            var teamToCreate = new TeamEntity
            {
                NationalityID = team.NationalityID,
                TeamName = team.TeamName,
                YearFounded = team.YearFounded,
                Headquarters = team.Headquarters,
            };

            await _teamRepo.AddTeamAsync(teamToCreate);
        }

        public async Task DeleteTeamAsync(Guid id)
        {
            await _teamRepo.RemoveTeamByIdAsync(id);
        }

        public async Task<IEnumerable<TeamDTO>> GetAllTeamsAsync()
        {
            var result = await _teamRepo.GetAllTeamsAsync();
            return result.Select(x => new TeamDTO
            {
                ID = x.ID,
                Name = x.TeamName,
                Headquarters = x.Headquarters,
                YearFounded = x.YearFounded,
                Country = x.Nationality.Name
            });
        }

        public async Task<TeamDTO> GetTeamByIdAsync(Guid id)
        {
            var result = await _teamRepo.GetTeamByIdAsync(id);
            return new TeamDTO() { Country = result.Nationality.Name, Headquarters = result.Headquarters, YearFounded = result.YearFounded, Name = result.TeamName, ID = result.ID };
        }

        public async Task UpdateTeamAsync(Guid id, JsonPatchDocument<TeamEntity> team)
        {
            await _teamRepo.UpdateTeamAsync(id, team);
        }
    }
}
