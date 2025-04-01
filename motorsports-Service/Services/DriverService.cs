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
        public DriverService(IDriverRepository driverRepository) { _driverRepository = driverRepository; }
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
            return await _driverRepository.GetAllDrivers();
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
