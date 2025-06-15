using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Logging;
using motorsports_Domain.Contracts;
using motorsports_Domain.Contracts.Service;
using motorsports_Domain.Entities;
using motorsports_Service.Contracts;
using motorsports_Service.DTOs;

namespace motorsports_Service.Services
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _personRepo;
        private readonly ICacheService _cacheService;
        private readonly ILogger<DriverService> _logger;

        public DriverService(IDriverRepository personRepo, ICacheService cacheService, ILogger<DriverService> logger)
        {
            _personRepo = personRepo;
            _cacheService = cacheService;
            _logger = logger;
        }

        public async Task<bool> CreateDriver(UploadPersonDTO uploadPersonDto)
        {
            var newPersonEntity = new DriverEntity
            {
                FirstName = uploadPersonDto.FirstName,
                LastName = uploadPersonDto.LastName,
                MiddleName = uploadPersonDto.MiddleName,
                BirthDate = uploadPersonDto.BirthDate,
                Gender = uploadPersonDto.Gender,
                NationalityID = uploadPersonDto.NationalityID,
                TeamID = uploadPersonDto.TeamID,
                ImageUrl = uploadPersonDto.ImageUrl,
                Description = uploadPersonDto.Description
            };
            await _personRepo.CreateDriver(newPersonEntity);
            return true;
        }

        public Task DeleteDriver(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PersonDTO>> GetAllDrivers()
        {
           var persons = await _personRepo.GetAllDrivers();
            return persons.Select(x => new PersonDTO
            {
                ID = x.ID,
                FirstName = x.FirstName,
                LastName = x.LastName,
                BirthDate = x.BirthDate,
                Gender =  x.Gender.ToString(),
                Nationality = x.Nationality.Name,
                RaceNumber = x.RaceNumber ?? 0,
            });
        }

        public async Task<PersonDTO> GetDriverById(Guid id)
        {
            var driver = await _personRepo.GetDriverById(id);
            var DTO = new PersonDTO
            {
                ID = driver.ID,
                FirstName = driver.FirstName,
                LastName = driver.LastName,
                BirthDate = driver.BirthDate,
            };
            return DTO;
        }

        public Task<PersonDTO> UpdateDriver(Guid id, JsonPatchDocument<DriverEntity> driver)
        {
            throw new NotImplementedException();
        }
    }
}
