using motorsports_Domain.Contracts;
using motorsports_Domain.Entities;
using motorsports_Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace motorsports_Service.Services
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepository;
        private readonly ICacheService _cacheService;
        private readonly TimeSpan _cacheDuration = TimeSpan.FromMinutes(10);
        const string cacheKey = "drivers_list";
        public DriverService(IDriverRepository driverRepository, ICacheService cacheService) { _driverRepository = driverRepository; _cacheService = cacheService; }
        public Task<Driver> CreateDriver(Driver driver)
        {
            throw new NotImplementedException();
        }

        public Task<Driver> DeleteDriver(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Driver>> GetAllDrivers()
        {
            
            var cachedDrivers = await _cacheService.GetAsync<IEnumerable<Driver>>(cacheKey);
            if (cachedDrivers != null)
            {
                Console.WriteLine("from Cache");
                return cachedDrivers;
            }
            Console.WriteLine("in service");
            var drivers = await _driverRepository.GetAllDrivers();
            await _cacheService.SetAsync(cacheKey, drivers, _cacheDuration);
            return drivers;
        }

        public Task<Driver> GetDriverById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Driver> UpdateDriver(Driver driver)
        {
            throw new NotImplementedException();
        }
    }
}
