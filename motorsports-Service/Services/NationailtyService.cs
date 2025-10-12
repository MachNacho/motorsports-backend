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

            var nationsDTO = nationsList.Select(n => new NationalityDTO { Id = n.Id, Code = n.Code, Continent = n.Continent.ToString().Replace("_", " "), Name = n.Name }).ToList().AsReadOnly();
            return nationsDTO;
        }
    }
}