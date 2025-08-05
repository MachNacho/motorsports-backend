using Microsoft.AspNetCore.JsonPatch;
using motorsports_Domain.Entities;

namespace motorsports_Domain.Contracts
{
    public interface IDriverRepository
    {
        Task<IEnumerable<DriverEntity>> GetAllDrivers();
        Task<DriverEntity> GetDriverById(Guid id);
        Task<DriverEntity> CreateDriver(DriverEntity driver);
        Task UpdateDriver(Guid id, JsonPatchDocument<DriverEntity> driver);
        Task DeleteDriver(Guid id);
    }
}
