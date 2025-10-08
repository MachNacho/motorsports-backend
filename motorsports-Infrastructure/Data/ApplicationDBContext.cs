using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using motorsports_Domain.Entities;
using motorsports_Domain.Entities.@base;
using System.Linq.Expressions;

namespace motorsports_Infrastructure.Data
{
    public class ApplicationDBContext : IdentityDbContext<UserEntity>
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<DriverEntity> Driver { get; set; }
        public DbSet<TeamEntity> Team { get; set; }
        public DbSet<NationalityEntity> Nationailty { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Entity Relationships
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DriverEntity>()
                .HasOne(d => d.Team) // Configures the relationship: PersonEntity has one Team
                .WithMany(t => t.Drivers) // TeamEntity has many Employees (PersonEntity)
                .HasForeignKey(d => d.TeamId) // Foreign key in PersonEntity is TeamID
                .OnDelete(DeleteBehavior.Restrict); // Cascade delete behavior

            modelBuilder.Entity<NationalityEntity>()
                .HasMany(n => n.Drivers) // NationalityEntity has many PersonEntity
                .WithOne(p => p.Nationality) // PersonEntity has one NationalityEntity
                .HasForeignKey(p => p.NationalityId) // Foreign key in PersonEntity
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            modelBuilder.Entity<NationalityEntity>()
                .HasMany(n => n.Teams) // NationalityEntity has many TeamEntity
                .WithOne(t => t.Nationality) // TeamEntity has one NationalityEntity
                .HasForeignKey(t => t.NationalityId) // Foreign key in TeamEntity
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete
            #endregion

            #region Roles
            List<IdentityRole> roles = new List<IdentityRole>()
            {
                new IdentityRole{
                    Id = "1d0f5b60-fd58-4cfb-9e13-11cbf9c59eae", // static Guid
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                },
                new IdentityRole{
                    Id = "dd0878b9-b15b-4049-9db4-d91cc01b5c3e", // static Guid
                    Name = "User",
                    NormalizedName = "USER",
                }
            };
            modelBuilder.Entity<IdentityRole>().HasData(roles);
            #endregion

            #region Global query filter
            // Apply global query filter to all entities derived from BaseEntity
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // Only apply filter to entities inheriting from BaseEntity
                if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
                {
                    // Build expression: e => !e.IsDeleted
                    var parameter = Expression.Parameter(entityType.ClrType, "e");
                    var deletedProp = Expression.Property(parameter, nameof(BaseEntity.IsDeleted));
                    var compare = Expression.Equal(deletedProp, Expression.Constant(false));
                    var lambda = Expression.Lambda(compare, parameter);

                    modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);
                }
            }
            #endregion
        }
        #region Save changes override
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
        #endregion
    }
}
