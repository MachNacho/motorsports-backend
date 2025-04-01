using motorsports_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace motorsports_Domain.Contracts
{
    public interface IDriverRepository
    {
        Task<IEnumerable<Driver>> GetAllDrivers();
        Task<Driver> GetDriverById(int id);
        Task<Driver> CreateDriver(Driver driver);
        Task<Driver> UpdateDriver(Driver driver);
        Task<Driver> DeleteDriver(int id);
    }
}
