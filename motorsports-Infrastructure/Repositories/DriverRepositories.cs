using motorsports_Domain.Contracts;
using motorsports_Domain.Entities;

namespace motorsports_Infrastructure.Repositories
{
    public class DriverRepositories : IDriverRepository
    {
        public Task<Driver> CreateDriver(Driver driver)
        {
            throw new NotImplementedException();
        }

        public Task<Driver> DeleteDriver(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Driver>> GetAllDrivers()
        {
            throw new NotImplementedException();
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
