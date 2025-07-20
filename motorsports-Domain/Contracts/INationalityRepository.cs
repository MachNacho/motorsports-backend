using motorsports_Domain.Entities;

namespace motorsports_Domain.Contracts
{
    public interface INationalityRepository
    {
        Task<IEnumerable<NationalityEntity>> GetAllNationalities(string? query);
        Task<NationalityEntity> CreateEntity(NationalityEntity entity);
    }
}
