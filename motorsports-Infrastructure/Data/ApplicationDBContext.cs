using Microsoft.EntityFrameworkCore;
using motorsports_Domain.Entities;
using motorsports_Domain.Entities.@base;

namespace motorsports_Infrastructure.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<DriverEntity> Person { get; set; }
        public DbSet<TeamEntity> Team { get; set; }
        public DbSet<NationalityEntity> Nationailty { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DriverEntity>()
                .HasOne(d => d.Team) // Configures the relationship: PersonEntity has one Team
                .WithMany(t => t.Employees) // TeamEntity has many Employees (PersonEntity)
                .HasForeignKey(d => d.TeamID) // Foreign key in PersonEntity is TeamID
                .OnDelete(DeleteBehavior.Restrict); // Cascade delete behavior

            modelBuilder.Entity<NationalityEntity>()
                .HasMany(n => n.persons) // NationalityEntity has many PersonEntity
                .WithOne(p => p.Nationality) // PersonEntity has one NationalityEntity
                .HasForeignKey(p => p.NationalityID) // Foreign key in PersonEntity
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            modelBuilder.Entity<NationalityEntity>()
                .HasMany(n => n.teams) // NationalityEntity has many TeamEntity
                .WithOne(t => t.Nationality) // TeamEntity has one NationalityEntity
                .HasForeignKey(t => t.NationalityID) // Foreign key in TeamEntity
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete
        }

        // DbContext SaveChanges override
        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries<BaseEntity>();

            foreach (var entry in entries)
            {
                entry.Entity.UpdatedAt = DateTime.UtcNow;
            }

            return base.SaveChanges();
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<BaseEntity>();

            foreach (var entry in entries)
            {
                entry.Entity.UpdatedAt = DateTime.UtcNow;
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
