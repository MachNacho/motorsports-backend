using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Logging;
using motorsports_Domain.Contracts;
using motorsports_Domain.Contracts.Service;
using motorsports_Domain.Entities;
using motorsports_Service.Contracts;
using motorsports_Service.DTOs.Driver;
using static motorsports_Domain.Constants.Constants;

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

        public async Task CreateDriver(UploadDriverDTO uploadDriverDTO)
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
            await _cacheService.RemoveAsync(CacheKeys.Drivers);
        }

        public async Task DeleteDriver(Guid id)
        {
            await _driverRepo.DeleteDriver(id);
            await _cacheService.RemoveAsync(CacheKeys.Drivers);
        }

        public async Task<IEnumerable<DriverDTO>> GetAllDrivers()
        {
            var drivers = await _cacheService.GetAsync<IEnumerable<DriverEntity>>(CacheKeys.Drivers);

            if (drivers == null)
            {
                drivers = await _driverRepo.GetAllDrivers();
                await _cacheService.SetAsync(CacheKeys.Drivers, drivers);
            }

            return drivers.Select(x => new DriverDTO
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

        public async Task<FullDriverDTO> GetDriverById(Guid id)
        {
            var driver = await _driverRepo.GetDriverById(id);
            var d = new FullDriverDTO
            {
                ID = driver.ID,
                FirstName = driver.FirstName,
                LastName = driver.LastName,
                BirthDate = driver.BirthDate,
                Gender = driver.Gender.ToString(),
                RaceNumber = driver.RaceNumber ?? 0,

                TeamID = driver.TeamID,
                TeamnNme = driver.Team.TeamName,

                Continent = driver.Nationality.Continent.ToString(),
                NationCode = driver.Nationality.Code,
                NationName = driver.Nationality.Name,
                NationID = driver.Nationality.ID,

            };
            return d;
        }

        public async Task UpdateDriver(Guid id, JsonPatchDocument<DriverEntity> driver)
        {
            await _driverRepo.UpdateDriver(id, driver);
            await _cacheService.RemoveAsync(CacheKeys.Drivers);
        }
    }
}
