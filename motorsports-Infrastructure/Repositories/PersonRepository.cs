using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using motorsports_Domain.Contracts;
using motorsports_Domain.Entities;
using motorsports_Domain.Exceptions;
using motorsports_Infrastructure.Data;
using motorsports_Infrastructure.Exceptions;

namespace motorsports_Infrastructure.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly ILogger<PersonRepository> _logger;

        public PersonRepository(ApplicationDBContext context, ILogger<PersonRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<DriverEntity> CreateDriver(DriverEntity driver)
        {
            try
            {
                driver.CreatedAt = DateTime.UtcNow;

                await _context.Person.AddAsync(driver);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Driver created: {@Driver}", driver);
                return driver;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating driver");
                throw new BusinessRuleViolationException($"Error creating driver: {ex.Message}", ex);
            }
        }

        public async Task<bool> DeleteDriver(Guid id)
        {
            try
            {
                var drivertodelete = await GetDriverById(id);
                drivertodelete.IsActive = false; // Soft delete
                await _context.SaveChangesAsync();

                _logger.LogInformation("Deleted driver ID: {Id}", id);
                return true;
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Driver not found: {Id}", id);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting driver: {Id}", id);
                throw new DatabaseException($"Error deleting driver: {ex.Message}", ex);
            }


        }
        public async Task<IEnumerable<DriverEntity>> GetAllDrivers()
        {
            try
            {
                var activePersons = await _context.Person.AsNoTracking().Where(d => d.IsActive).ToListAsync();

                if (activePersons == null || activePersons.Count == 0)
                {
                    _logger.LogWarning("No active drivers found");
                    throw new EmptyOrNoRecordsException("No drivers found");
                }

                _logger.LogInformation("Retrieved {Count} active drivers", activePersons.Count);
                return activePersons;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving drivers");
                throw;
            }
        }

        public async Task<DriverEntity> GetDriverById(Guid id)
        {
            try
            {
                var driver = await _context.Person.FindAsync(id);
                if (driver == null || !driver.IsActive)
                {
                    _logger.LogWarning("Driver with ID {Id} not found or inactive", id);
                    throw new NotFoundException($"Driver with ID {id} not found");
                }

                _logger.LogInformation("Driver with ID {Id} retrieved", id);
                return driver;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<DriverEntity> UpdateDriver(Guid id, JsonPatchDocument<DriverEntity> driver)
        {
            try
            {   
                var driverToUpdate = await GetDriverById(id);

                driver.ApplyTo(driverToUpdate);
                
                await _context.SaveChangesAsync();

                _logger.LogInformation("Driver updated: {@Driver}", driverToUpdate);
                return driverToUpdate;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Update error for driver ID {Id}", id);
                throw new BusinessRuleViolationException($"Update error occurred: {ex.Message}", ex);
            }
        }
    }
}
