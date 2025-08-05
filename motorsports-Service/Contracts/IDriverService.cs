using Microsoft.AspNetCore.JsonPatch;
using motorsports_Domain.Entities;
using motorsports_Service.DTOs.Driver;

namespace motorsports_Service.Contracts
{
    public interface IDriverService
    {
        Task<IEnumerable<DriverDTO>> GetAllDrivers();
        Task<FullDriverDTO> GetDriverById(Guid id);
        Task CreateDriver(UploadDriverDTO uploadDriverDTO);
        Task UpdateDriver(Guid id, JsonPatchDocument<DriverEntity> driver);
        Task DeleteDriver(Guid id);
    }
}
