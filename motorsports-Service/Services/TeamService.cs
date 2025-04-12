using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using motorsports_Domain.Contracts;
using motorsports_Domain.Entities;
using motorsports_Service.Contracts;
using motorsports_Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace motorsports_Service.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly ICacheRepository _cacheService;
        private readonly IMapper _mapper;
        const string cacheKey = "team_list";
        public TeamService(ITeamRepository teamRepository, ICacheRepository cacheService, IMapper mapper)
        {
            _teamRepository = teamRepository;
            _cacheService = cacheService;
            _mapper = mapper;
        }
        public Task<bool> CreateTeam(TeamDTO team)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTeam(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TeamDTO>> GetAllTeams()
        {
            var cachedTeams = await _cacheService.GetAsync<IEnumerable<TeamDTO>>(cacheKey);
            if (cachedTeams != null)
            {
                return cachedTeams;
            }
            var teams = await _teamRepository.GetAllTeams();
            var teamDTOs = teams.Select(t => _mapper.Map<TeamDTO>(t));
            await _cacheService.SetAsync(cacheKey, teamDTOs);
            return teamDTOs;
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
