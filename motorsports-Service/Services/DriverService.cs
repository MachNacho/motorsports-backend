using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Logging;
using motorsports_Domain.Contracts;
using motorsports_Domain.Contracts.Service;
using motorsports_Domain.Entities;
using motorsports_Service.Contracts;
using motorsports_Service.DTOs;
using motorsports_Service.DTOs.Driver;

namespace motorsports_Service.Services
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepo;
        private readonly ICacheService _cacheService;
        private readonly ILogger<DriverService> _logger;

        public DriverService(IDriverRepository driverRepo, ICacheService cacheService, ILogger<DriverService> logger)
        {
            _driverRepo = driverRepo;
            _cacheService = cacheService;
            _logger = logger;
        }

        public async Task<bool> CreateDriver(UploadDriverDTO uploadDriverDTO)
        {
            var newPersonEntity = new DriverEntity
            {
                FirstName = uploadDriverDTO.FirstName,
                LastName = uploadDriverDTO.LastName,
                MiddleName = uploadDriverDTO.MiddleName,
                BirthDate = uploadDriverDTO.BirthDate,
                Gender = uploadDriverDTO.Gender,
                NationalityID = uploadDriverDTO.NationalityID,
                TeamID = uploadDriverDTO.TeamID,
                ImageUrl = uploadDriverDTO.ImageUrl,
                Description = uploadDriverDTO.Description
            };
            await _driverRepo.CreateDriver(newPersonEntity);
            return true;
        }

        public async Task DeleteDriver(Guid id)
        {
            await _driverRepo.DeleteDriver(id);
        }

        public async Task<IEnumerable<PersonDTO>> GetAllDrivers()
        {
            var persons = await _driverRepo.GetAllDrivers();
            return persons.Select(x => new PersonDTO
            {
                ID = x.ID,
                FirstName = x.FirstName,
                LastName = x.LastName,
                BirthDate = x.BirthDate,
                Gender = x.Gender.ToString(),
                Nationality = x.Nationality.Name,
                RaceNumber = x.RaceNumber ?? 0,
            });
        }

        public async Task<DriverEntity> GetDriverById(Guid id)
        {
            var driver = await _driverRepo.GetDriverById(id);
            return driver;
        }

        public Task<PersonDTO> UpdateDriver(Guid id, JsonPatchDocument<DriverEntity> driver)
        {
            throw new NotImplementedException();
        }
    }
}
