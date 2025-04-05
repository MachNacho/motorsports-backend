using Microsoft.AspNetCore.JsonPatch;
using motorsports_Domain.Entities;

namespace motorsports_Domain.Contracts
{
    public interface IDriverRepository
    {
        Task<IEnumerable<DriverEntity>> GetAllDrivers();
        Task<DriverEntity> GetDriverById(int id);
        Task<bool> CreateDriver(DriverEntity driver);
        Task<DriverEntity> UpdateDriver(int id, JsonPatchDocument<DriverEntity> driver);
        Task<bool> DeleteDriver(int id);
    }
}
