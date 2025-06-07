using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using motorsports_Domain.Contracts;
using motorsports_Domain.Entities;
using motorsports_Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<NationalityEntity> CreateEntity(NationalityEntity entity)
        {
            try
            {
                entity.CreatedAt = DateTime.UtcNow;
                entity.IsActive = true;

                await _context.Nationailty.AddAsync(entity);
                await _context.SaveChangesAsync();

                _logger.LogInformation("NationalityEntity created successfully with ID: {ID}", entity.ID);
                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating NationalityEntity");
                throw;
            }
        }

        public async Task<IEnumerable<NationalityEntity>> GetAllNationalities(string? query)
        {
            return await _context.Nationailty.ToListAsync();
        }
    }
}
