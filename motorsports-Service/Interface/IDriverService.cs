using motorsports_Service.DTOs.Driver;

namespace motorsports_Service.Interface
{
    public interface IDriverService
    {
        Task<IReadOnlyCollection<DriverDTO>> GetAllDriversAsync();
        Task<FullDriverDTO?> GetDriverByIdAsync(Guid id);
        Task<FullDriverDTO> CreateDriverAsync(UploadDriverDTO uploadDriverDTO);
        Task UpdateDriverAsync(Guid id, UpdateDriverDTO driverDTO);
        Task DeleteDriverAsync(Guid id);
    }
}
