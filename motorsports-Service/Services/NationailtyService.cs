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
                Continent = nationalityDto.Continent,
                FlagUrl = nationalityDto.FlagUrl,
            };
            await _nationalityRepo.CreateEntity(newNationalityEntity);
            return nationalityDto;
        }

        public Task<bool> DeleteNationalityAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<NationalityDTO>> GetAllNationalitiesAsync(string? query)
        {
            throw new NotImplementedException();
        }

        public Task<NationalityDTO> GetNationalityByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<NationalityDTO> UpdateNationalityAsync(Guid id, NationalityDTO nationalityDto)
        {
            throw new NotImplementedException();
        }
    }
}
