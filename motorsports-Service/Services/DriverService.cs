using Microsoft.Extensions.Logging;
using motorsports_Domain.Entities;
using motorsports_Domain.Interfaces;
using motorsports_Service.DTOs.Driver;
using motorsports_Service.Helpers;
using motorsports_Service.Interface;
using static motorsports_Domain.Constants.Constants;

namespace motorsports_Service.Services
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepo;
        private readonly ICacheIntegration _cacheIntegration;
        private readonly ILogger<DriverService> _logger;

        public DriverService(IDriverRepository driverRepo, ICacheIntegration cacheIntegration, ILogger<DriverService> logger)
        {
            _driverRepo = driverRepo;
            _cacheIntegration = cacheIntegration;
            _logger = logger;
        }

        public async Task<DriverEntity> CreateDriverAsync(UploadDriverDTO uploadDriverDTO)
        {
            var newDriver = new DriverEntity()
            {
                FirstName = uploadDriverDTO.FirstName,
                LastName = uploadDriverDTO.LastName,
                BirthDate = uploadDriverDTO.BirthDate,
                RaceNumber = uploadDriverDTO.RaceNumber,
                TeamId = uploadDriverDTO.TeamID,
                NationalityId = uploadDriverDTO.NationalityID,
                MiddleName = uploadDriverDTO.MiddleName,
                Gender = uploadDriverDTO.Gender,
            };

            var result = await _driverRepo.CreateDriverAsync(newDriver);
            return result;
        }

        public async Task DeleteDriverAsync(Guid id)
        {
            await _driverRepo.DeleteDriverAsync(id);
        }

        public async Task<IReadOnlyCollection<DriverDTO>> GetAllDriversAsync()
        {
            var cached = await _cacheIntegration.GetAsync<IReadOnlyCollection<DriverDTO>>(CacheKeys.Drivers);
            if (cached != null)
            {
                return cached;
            }

            var drivers = await _driverRepo.GetAllDriversAsync();

            var driverDTO = drivers.Select(x => new DriverDTO
            {
                Id = x.Id,
                Firstname = x.FirstName,
                Lastname = x.LastName,
                Code = x.Nationality.Code,
                FlagOneByOne = x.Nationality.FlagOneByOne,
                RaceNumber = x.RaceNumber,
                TeamName = x.Team.TeamName,
            }).ToList().AsReadOnly();

            await _cacheIntegration.SetAsync<IReadOnlyCollection<DriverDTO>>(CacheKeys.Drivers, driverDTO);
            return driverDTO;
        }

        public async Task<FullDriverDTO?> GetDriverByIdAsync(Guid id)
        {
            var driver = await _driverRepo.GetDriverByIdAsync(id);
            var driverDTO = new FullDriverDTO
            {
                Id = driver.Id,
                Firstname = driver.FirstName,
                Lastname = driver.LastName,
                Nationality = driver.Nationality.Name,
                Code = driver.Nationality.Code,
                FlagFourByThree = driver.Nationality.FlagFourByThree,
                FlagOneByOne = driver.Nationality.FlagOneByOne,
                Gender = driver.Gender.ToString(),
                RaceNumber = driver.RaceNumber,
                TeamName = driver.Team.TeamName,
                TeamId = driver.TeamId,
                BirthDate = driver.BirthDate,
            };
            return driverDTO;
        }

        public async Task UpdateDriverAsync(Guid id, UpdateDriverDTO driverDTO)
        {
            var driver = await _driverRepo.GetDriverByIdAsync(id);
            DriverUpdateHelper.ApplyDriverUpdates(driver, driverDTO);
            await _driverRepo.UpdateDriverAsync(driver);
        }
    }
}
