using motorsports_Domain.Entities;

namespace motorsports_Service.Contracts
{
    public interface IDriverService
    {
        Task<IEnumerable<Driver>> GetAllDrivers();
        Task<Driver> GetDriverById(int id);
        Task<Driver> CreateDriver(Driver driver);
        Task<Driver> UpdateDriver(Driver driver);
        Task<Driver> DeleteDriver(int id);
    }
}
