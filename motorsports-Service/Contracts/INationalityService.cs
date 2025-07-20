using motorsports_Service.DTOs;

namespace motorsports_Service.Contracts
{
    public interface INationalityService
    {
        // Retrieves all nationalities, optionally filtered by a query string
        Task<IEnumerable<NationalityDTO>> GetAllNationalitiesAsync(string? query);

        // Retrieves a single nationality by its ID
        Task<NationalityDTO> GetNationalityByIdAsync(Guid id);

        // Creates a new nationality
        Task<NationalityDTO> CreateNationalityAsync(NationalityDTO nationalityDto);

        // Updates an existing nationality
        Task<NationalityDTO> UpdateNationalityAsync(Guid id, NationalityDTO nationalityDto);

        // Deletes a nationality by its ID
        Task<bool> DeleteNationalityAsync(Guid id);
    }
}
