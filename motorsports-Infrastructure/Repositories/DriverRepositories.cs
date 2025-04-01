using Microsoft.EntityFrameworkCore;
using motorsports_Domain.Contracts;
using motorsports_Domain.Entities;
using motorsports_Infrastructure.Data;

namespace motorsports_Infrastructure.Repositories
{
    public class DriverRepositories : IDriverRepository
    {
        //Get DB context
        private readonly ApplicationDBContext _context;
        //Constructor using dependency injection
        public DriverRepositories(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<string> CreateDriver(Driver driver)
        {
            await _context.Driver.AddAsync(driver);
            await _context.SaveChangesAsync();
            return "Driver created successfully";
        }

        public Task<Driver> DeleteDriver(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Driver>> GetAllDrivers()
        {
            Console.WriteLine("In repo");
            return await _context.Driver.AsNoTracking().ToListAsync();
        }

        public Task<Driver> GetDriverById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Driver> UpdateDriver(Driver driver)
        {
            throw new NotImplementedException();
        }
    }
}
