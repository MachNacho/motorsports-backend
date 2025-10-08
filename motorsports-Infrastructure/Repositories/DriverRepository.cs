using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using motorsports_Domain.Entities;
using motorsports_Domain.Interfaces;
using motorsports_Infrastructure.Data;
using static motorsports_Domain.Exceptions.ExceptionsList;

namespace motorsports_Infrastructure.Repositories
{
    public class DriverRepository : IDriverRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly ILogger<DriverRepository> _logger;

        public DriverRepository(ApplicationDBContext context, ILogger<DriverRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<DriverEntity> CreateDriverAsync(DriverEntity driver)
        {
            await _context.Driver.AddAsync(driver);
            await _context.SaveChangesAsync();
            return driver;
        }

        public async Task DeleteDriverAsync(Guid id)
        {
            var driverToDelete = await _context.Driver.FindAsync(id);
            if (driverToDelete is null)
            {
                _logger.LogWarning("Attempted to delete driver with ID {DriverId}, but it was not found.", id);
                throw new RecordNotFound($"Driver with ID '{id}' not found.");
            }
            driverToDelete.MarkAsDeleted();
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyCollection<DriverEntity>> GetAllDriversAsync()
        {
            var drivers = await _context.Driver.Include(x => x.Nationality).Include(x => x.Team).AsNoTracking().ToListAsync();
            return drivers.AsReadOnly();
        }

        public async Task<DriverEntity?> GetDriverByIdAsync(Guid id)
        {
            var driver = await _context.Driver.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
            return driver;
        }

        public async Task UpdateDriverAsync(DriverEntity driver)
        {
            var existingDriver = await _context.Driver.FindAsync(driver.Id);
            if (existingDriver is null)
            {
                _logger.LogWarning("Attempted to update driver with ID {DriverId}, but it was not found.", driver.Id);
                throw new RecordNotFound($"Driver with ID '{driver.Id}' not found.");
            }
            _context.Entry(existingDriver).CurrentValues.SetValues(driver);
            await _context.SaveChangesAsync();
        }
    }
}
