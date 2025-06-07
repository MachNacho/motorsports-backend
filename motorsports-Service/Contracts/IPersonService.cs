using Microsoft.AspNetCore.JsonPatch;
using motorsports_Domain.Entities;
using motorsports_Service.DTOs;

namespace motorsports_Service.Contracts
{
    public interface IPersonService
    {
        Task<IEnumerable<PersonDTO>> GetAllDrivers();
        Task<PersonDTO> GetDriverById(Guid id);
        Task<bool> CreateDriver(UploadPersonDTO uploadPersonDto);
        Task<PersonDTO> UpdateDriver(Guid id, JsonPatchDocument<DriverEntity> driver);
        Task<bool> DeleteDriver(Guid id);
    }
}
