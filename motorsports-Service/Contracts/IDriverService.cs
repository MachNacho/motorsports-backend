using Microsoft.AspNetCore.JsonPatch;
using motorsports_Domain.Entities;
using motorsports_Service.DTOs;
using motorsports_Service.DTOs.Driver;

namespace motorsports_Service.Contracts
{
    public interface IDriverService
    {
        Task<IEnumerable<PersonDTO>> GetAllDrivers();
        Task<DriverEntity> GetDriverById(Guid id);
        Task<bool> CreateDriver(UploadDriverDTO uploadDriverDTO);
        Task<PersonDTO> UpdateDriver(Guid id, JsonPatchDocument<DriverEntity> driver);
        Task DeleteDriver(Guid id);
    }
}
