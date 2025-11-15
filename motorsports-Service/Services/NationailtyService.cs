using motorsports_Domain.Interfaces;
using motorsports_Service.DTOs.Nationality;
using motorsports_Service.Interface;

namespace motorsports_Service.Services
{
    public class NationailtyService : INationalityService
    {
        private readonly INationalityRepository _nationalityRepo;
        public NationailtyService(INationalityRepository nationalityRepo)
        {
            _nationalityRepo = nationalityRepo;
        }
        public async Task<IReadOnlyCollection<NationalityDTO>> GetAllNations()
        {
            var nationsList = await _nationalityRepo.GetAllNationalitiesAsync();

            var nationsDTO = nationsList.Select(n => new NationalityDTO { Id = n.Id, label = n.Name }).ToList().AsReadOnly();
            return nationsDTO;
        }

        public async Task<IReadOnlyCollection<NationStatsDTO>> GetStatsAsync()
        {
            var nationStats = await _nationalityRepo.GetAllNationStats();
            var results = nationStats.Select(n => new NationStatsDTO
            {
                Code = n.Code,
                Continent = n.Continent.ToString().Replace("_", " "),
                Name = n.Name,
                CircutCount = n.RaceTrack.Count(),
                TeamCount = n.Teams.Count(),
                DriverCount = n.Drivers.Count(),
            }).OrderByDescending(n => n.CircutCount + n.TeamCount + n.DriverCount).ToList().AsReadOnly();
            return results;
        }
    }
}