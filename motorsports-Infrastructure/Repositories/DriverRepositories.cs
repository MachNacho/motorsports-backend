using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using motorsports_Domain.Contracts;
using motorsports_Domain.Entities;
using motorsports_Domain.Exceptions;
using motorsports_Infrastructure.Data;
using motorsports_Infrastructure.Exceptions;

namespace motorsports_Infrastructure.Repositories
{
    public class DriverRepositories : IDriverRepository
    {
        private readonly ApplicationDBContext _context;
        public DriverRepositories(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateDriver(DriverEntity driver)
        {
            try
            {
                driver.IsActive = true;
                driver.CreatedAt = DateTime.UtcNow;
                driver.UpdatedAt = DateTime.UtcNow;
                await _context.Driver.AddAsync(driver);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw new BusinessRuleViolationException("Error creating driver");
            }

        }

        public async Task<bool> DeleteDriver(int id)
        {

            try
            {
                var drivertodelete = await GetDriverById(id);
                if (drivertodelete != null)
                {
                    _context.Remove(drivertodelete);
                    await _context.SaveChangesAsync();
                    return true;
                }
                throw new NotFoundException("Driver not found");
            }
            catch (NotFoundException ex)
            {
                throw new NotFoundException($"Driver not found {ex}");
            }
            catch (Exception ex)
            {
                throw new DatabaseException($"Error deleting driver: {ex}");
            }


        }
        public async Task<IEnumerable<DriverEntity>> GetAllDrivers()
        {
            try
            {
                var drivers = await _context.Driver.AsNoTracking().Where(d => d.IsActive).ToListAsync();
                return drivers.Count == 0 ? throw new EmptyOrNoRecordsException("No drivers found") : drivers;
            }
            catch (Exception)
            {
                throw new DatabaseException("Error searching for drivers");
            }
        }

        public async Task<DriverEntity> GetDriverById(int id)
        {
            try
            {
                var driver = await _context.Driver.FindAsync(id);
                return driver;
            }
            catch (Exception)
            {
                throw new NotFoundException($"Driver with ID {id} not found");
            }

        }

        public async Task<DriverEntity> UpdateDriver(int id, JsonPatchDocument<DriverEntity> driver)
        {
            try
            {
                var OGmodel = await GetDriverById(id);
                OGmodel.UpdatedAt = DateTime.UtcNow;
                driver.ApplyTo(OGmodel);
                await _context.SaveChangesAsync();
                return OGmodel;
            }
            catch (Exception)
            {
                throw new BusinessRuleViolationException("Update error occured");
            }

        }
    }
}
