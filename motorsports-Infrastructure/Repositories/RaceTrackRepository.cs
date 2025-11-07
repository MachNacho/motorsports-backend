using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using motorsports_Domain.Entities;
using motorsports_Domain.Interfaces;
using motorsports_Infrastructure.Data;

namespace motorsports_Infrastructure.Repositories
{
    public class RaceTrackRepository : IRaceTrackRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly ILogger<RaceTrackRepository> _logger;
        public RaceTrackRepository(ApplicationDBContext context, ILogger<RaceTrackRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<IReadOnlyCollection<RaceTrackEntity>> GetAllRaceTrack()
        {
            var result = await _context.RaceTrack.Include(x => x.nation).AsNoTracking().ToListAsync();
            return result.AsReadOnly();
        }

        public async Task<RaceTrackEntity?> GetRaceTrackById(Guid id)
        {
            var result = await _context.RaceTrack.Include(x => x.nation).AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
            return result;
        }
    }
}
