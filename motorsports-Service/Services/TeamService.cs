using motorsports_Domain.Entities;
using motorsports_Domain.Interfaces;
using motorsports_Service.DTOs.Team;
using motorsports_Service.Interface;

namespace motorsports_Service.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;
        public TeamService(ITeamRepository teamRepository) { _teamRepository = teamRepository; }

        public async Task<TeamEntity> CreateTeamAsync(TeamEntity team)
        {
            var result = await _teamRepository.CreateTeamAsync(team);
            return result;
        }

        public async Task DeleteTeamAsync(Guid id)
        {
            await _teamRepository.DeleteTeamAsync(id);
        }

        public async Task<IReadOnlyCollection<TeamDTO>> GetAllTeamAsync()
        {
            var result = await _teamRepository.GetAllTeamsAsync();
            var teamDTO = result.Select(x => new TeamDTO
            {
                ID = x.Id,
                Country = x.Nationality.Name,
                Code = x.Nationality.Code,
                Headquarters = x.Headquarters,
                Name = x.TeamName,
                YearFounded = (DateOnly)x.FoundedDate,
            }).ToList().AsReadOnly();
            return teamDTO;
        }

        public async Task<IReadOnlyCollection<TeamOptionsDTO>> GetAllTeamsForOptionsAsync()
        {

            var result = await _teamRepository.GetAllTeamsAsync();
            var TeamOptions = result.Select(x => new TeamOptionsDTO
            {
                Id = x.Id,
                label = x.TeamName
            }).ToList().AsReadOnly();
            return TeamOptions;
        }

        public async Task<FullTeamDTO> GetTeamByIdAsync(Guid id)
        {
            var result = await _teamRepository.GetTeamByIdAsync(id);
            var teamDTO = new FullTeamDTO
            {
                TeamName = result.TeamName,
                FoundedDate = result.FoundedDate,
                nationName = result.Nationality.Name,
                nationCode = result.Nationality.Code,
                Headquarters = result.Headquarters,
                Drivers = result.Drivers.Select(d => new TeamDriver
                {
                    id = d.Id,
                    Firstname = d.FirstName,
                    Lasstname = d.LastName,
                    nationCode = d.Nationality.Code

                }).ToList().AsReadOnly()
            };
            return teamDTO;
        }

        public async Task UpdateTeamAsync(Guid id, TeamEntity team)
        {
            await _teamRepository.UpdateTeamAsync(team);
        }
    }
}
