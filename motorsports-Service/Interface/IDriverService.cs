using motorsports_Domain.Entities;
using motorsports_Service.DTOs.Driver;

namespace motorsports_Service.Interface
{
    /// <summary>
    /// Service layer for driver business logic.
    /// Handles validation, caching, and coordination between repository and presentation layers.
    /// </summary>
    public interface IDriverService
    {
        Task<IReadOnlyCollection<FullTableDriver>> GetAllDriversForTableAsync();
        Task<IReadOnlyCollection<DriverDTO>> GetAllDriversAsync();
        Task<FullDriverDTO?> GetDriverByIdAsync(Guid id);

        /// <summary>
        /// Creates a new driver in the system.
        /// Invalidates the drivers cache after successful creation.
        /// </summary>
        /// <param name="uploadDriverDTO">Driver information to create</param>
        /// <returns>The created driver entity</returns>
        /// <exception cref="ArgumentNullException">Thrown when uploadDriverDTO is null</exception>
        /// <exception cref="ArgumentException">Thrown when validation fails</exception>
        Task<DriverEntity> CreateDriverAsync(UploadDriverDTO uploadDriverDTO);
        Task UpdateDriverAsync(Guid id, UploadDriverDTO driverDTO);
        Task DeleteDriverAsync(Guid id);
    }
}
