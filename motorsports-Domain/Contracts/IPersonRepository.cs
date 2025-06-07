using Microsoft.AspNetCore.JsonPatch;
using motorsports_Domain.Entities;

namespace motorsports_Domain.Contracts
{
    public interface IPersonRepository
    {
        Task<IEnumerable<DriverEntity>> GetAllDrivers();
        Task<DriverEntity?> GetDriverById(Guid id);
        Task<DriverEntity> CreateDriver(DriverEntity driver);
        Task<DriverEntity?> UpdateDriver(Guid id, JsonPatchDocument<DriverEntity> driver);
        Task<bool> DeleteDriver(Guid id);
    }
}
