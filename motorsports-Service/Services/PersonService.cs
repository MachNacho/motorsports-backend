using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Logging;
using motorsports_Domain.Contracts;
using motorsports_Domain.Entities;
using motorsports_Domain.enums;
using motorsports_Service.Contracts;
using motorsports_Service.DTOs;

namespace motorsports_Service.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepo;
        private readonly ICacheService _cacheService;
        private readonly ILogger<PersonService> _logger;

        public PersonService(IPersonRepository personRepo, ICacheService cacheService, ILogger<PersonService> logger)
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

        public Task<bool> DeleteDriver(Guid id)
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
                BirthDate = x.BirthDate
            });
        }

        public Task<PersonDTO> GetDriverById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PersonDTO> UpdateDriver(Guid id, JsonPatchDocument<DriverEntity> driver)
        {
            throw new NotImplementedException();
        }
    }
}
