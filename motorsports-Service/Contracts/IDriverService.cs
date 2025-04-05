using Microsoft.AspNetCore.JsonPatch;
using motorsports_Domain.Entities;
using motorsports_Service.DTOs;

namespace motorsports_Service.Contracts
{
    public interface IDriverService
    {
        Task<IEnumerable<DriverDTO>> GetAllDrivers();
        Task<DriverEntity> GetDriverById(int id);
        Task<bool> CreateDriver(DriverDTO driver);
        Task<DriverEntity> UpdateDriver(int id, JsonPatchDocument<DriverEntity> driver);
        Task<bool> DeleteDriver(int id);
    }
}
