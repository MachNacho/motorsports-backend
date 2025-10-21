using motorsports_Domain.Entities;

namespace motorsports_Domain.Interfaces
{
    /// <summary>
    /// Repository contract for managing nationality entities.
    /// </summary>
    public interface INationalityRepository
    {
        /// <summary>
        /// Retrieves all nationalities from the data source.
        /// </summary>
        Task<IReadOnlyCollection<NationalityEntity>> GetAllNationalitiesAsync();
        Task<IReadOnlyCollection<NationalityEntity>> GetAllNationStats();
    }
}
