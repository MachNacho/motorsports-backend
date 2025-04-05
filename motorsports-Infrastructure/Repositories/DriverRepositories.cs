using Microsoft.AspNetCore.JsonPatch;
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
        public async Task<string> CreateDriver(DriverEntity driver)
        {
            await _context.Driver.AddAsync(driver);
            await _context.SaveChangesAsync();
            return "Driver created successfully";
        }

        public async Task<string> DeleteDriver(int id)
        {
            var drivertodelete = await _context.Driver.FirstOrDefaultAsync(d => d.ID == id);
            if (drivertodelete != null)
            {
                _context.Remove(drivertodelete);
                await _context.SaveChangesAsync();
                return "Driver is deleted";
            }
            return "Driver not found";
        }

        public async Task<IEnumerable<DriverEntity>> GetAllDrivers()
        {
            Console.WriteLine("In repo");
            return await _context.Driver.AsNoTracking().Where(d => d.IsActive).ToListAsync();
        }

        public async Task<DriverEntity> GetDriverById(int id)
        {
            var driver = await _context.Driver.FindAsync(id);
            return driver;
        }

        public async Task<DriverEntity> UpdateDriver(int id, JsonPatchDocument<DriverEntity> driver)
        {
            var OGmodel = await GetDriverById(id);
            driver.ApplyTo(OGmodel);
            await _context.SaveChangesAsync();
            return OGmodel;
        }
    }
}
