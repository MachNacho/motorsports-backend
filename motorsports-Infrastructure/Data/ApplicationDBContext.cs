using Microsoft.EntityFrameworkCore;
using motorsports_Domain.Entities;

namespace motorsports_Infrastructure.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<DriverEntity> Driver { get; set; }
    }
}
