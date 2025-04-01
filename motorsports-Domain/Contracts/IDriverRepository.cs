using motorsports_Domain.Entities;

namespace motorsports_Domain.Contracts
{
    public interface IDriverRepository
    {
        Task<IEnumerable<Driver>> GetAllDrivers();
        Task<Driver> GetDriverById(int id);
        Task<string> CreateDriver(Driver driver);
        Task<Driver> UpdateDriver(Driver driver);
        Task<Driver> DeleteDriver(int id);
    }
}
