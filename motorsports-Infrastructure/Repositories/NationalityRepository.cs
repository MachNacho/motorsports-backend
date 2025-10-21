using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using motorsports_Domain.Entities;
using motorsports_Domain.Interfaces;
using motorsports_Infrastructure.Data;

namespace motorsports_Infrastructure.Repositories
{
    public class NationalityRepository : INationalityRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly ILogger<NationalityRepository> _logger;

        public NationalityRepository(ApplicationDBContext context, ILogger<NationalityRepository> logger)
        {
            _context = context;
            _logger = logger;

        }

        public async Task<IReadOnlyCollection<NationalityEntity>> GetAllNationalitiesAsync()
        {
            var nations = await _context.Nationailty.AsNoTracking().ToListAsync();
            return nations.AsReadOnly();
        }

        public async Task<IReadOnlyCollection<NationalityEntity>> GetAllNationStats()
        {
            var stats = await _context.Nationailty.Include(n => n.Teams).Include(t => t.RaceTrack).Include(a => a.Drivers).AsNoTracking().ToListAsync();
            return stats.AsReadOnly();
        }
    }
}
