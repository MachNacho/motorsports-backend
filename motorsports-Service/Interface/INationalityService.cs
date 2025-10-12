using motorsports_Service.DTOs.Nationality;

namespace motorsports_Service.Interface
{
    public interface INationalityService
    {
        Task<IReadOnlyCollection<NationalityDTO>> GetAllNations();
    }
}
