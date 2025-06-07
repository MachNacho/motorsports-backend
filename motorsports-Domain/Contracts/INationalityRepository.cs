using motorsports_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace motorsports_Domain.Contracts
{
    public interface INationalityRepository
    {
        Task<IEnumerable<NationalityEntity>> GetAllNationalities(string? query);
        Task<NationalityEntity> CreateEntity(NationalityEntity entity);
    }
}
