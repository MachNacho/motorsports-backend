using motorsports_Domain.Entities;

namespace motorsports_Domain.Interfaces
{
    public interface IDriverRepository
    {
        /// <summary>
        /// Retrieves all drivers.
        /// </summary>
        Task<IReadOnlyCollection<DriverEntity>> GetAllDriversAsync();

        /// <summary>
        /// Retrieves a single driver by ID.
        /// Returns null if not found.
        /// </summary>
        Task<DriverEntity?> GetDriverByIdAsync(Guid id);

        /// <summary>
        /// Creates a new driver.
        /// </summary>
        Task<DriverEntity> CreateDriverAsync(DriverEntity driver);

        /// <summary>
        /// Updates an existing driver.
        /// </summary>
        Task UpdateDriverAsync(DriverEntity driver);

        /// <summary>
        /// Deletes a driver by ID.
        /// </summary>
        Task DeleteDriverAsync(Guid id);
    }
}
