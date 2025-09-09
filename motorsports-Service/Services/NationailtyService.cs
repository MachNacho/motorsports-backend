using motorsports_Domain.Constants;
using motorsports_Domain.Contracts;
using motorsports_Domain.Entities;
using motorsports_Service.Contracts;
using motorsports_Service.DTOs;

namespace motorsports_Service.Services
{
    public class NationailtyService : INationalityService
    {
        private readonly INationalityRepository _nationalityRepo;

        public NationailtyService(INationalityRepository nationalityRepo)
        {
            _nationalityRepo = nationalityRepo;
        }
        public async Task<NationalityDTO> CreateNationalityAsync(NationalityDTO nationalityDto)
        {
            var newNationalityEntity = new NationalityEntity
            {
                Name = nationalityDto.Name,
                Code = nationalityDto.Code,
                Continent = Enum.Parse<Constants.ContinentEnum>(nationalityDto.Continent),
                FlagUrl = nationalityDto.FlagUrl,
            };
            await _nationalityRepo.CreateEntity(newNationalityEntity);
            return nationalityDto;
        }

        public Task<bool> DeleteNationalityAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<NationalityDTO>> GetAllNationalitiesAsync(string? query)
        {
            var a = await _nationalityRepo.GetAllNationalities(query);
            return a.Select(x => new NationalityDTO
            {
                Name = x.Name,
                Code = x.Code,
                Continent = x.Continent.ToString(),
                FlagUrl = x.FlagUrl,
            });
        }

        public async Task<NationalityDTO> GetNationalityByIdAsync(Guid id)
        {

            throw new NotImplementedException();
        }

        public Task<NationalityDTO> UpdateNationalityAsync(Guid id, NationalityDTO nationalityDto)
        {
            throw new NotImplementedException();
        }
    }
}
