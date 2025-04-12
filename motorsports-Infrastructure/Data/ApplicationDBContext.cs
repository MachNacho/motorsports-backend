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
        public DbSet<TeamEntity> Team { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DriverEntity>()
                .HasOne(d => d.Team)
                .WithMany(t => t.Drivers)
                .HasForeignKey(d => d.TeamID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
