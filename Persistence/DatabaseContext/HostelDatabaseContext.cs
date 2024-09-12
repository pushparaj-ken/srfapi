using Application.Contracts.Identity;
using Domain;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DatabaseContext
{
    public class HostelDatabaseContext : DbContext
    {
        private readonly IUserService _userService;

        public HostelDatabaseContext(
            DbContextOptions<HostelDatabaseContext> options, IUserService userService) : base(options)
        {
            this._userService = userService;
        }

        public DbSet<AssetCategory> Assets { get; set; }

        public DbSet<RoomCategory> Room { get; set; }

        public DbSet<Master> Masters { get; set; }

        public DbSet<Lease> Lease { get; set; }

        public DbSet<GuestMaster> Guest { get; set; }

        public DbSet<StaffOccupancyType> StaffOccupancyType { get; set; }

        public DbSet<StudOccupancyType> StudOccupancyType { get; set; }

        public DbSet<HostelMaster> Hostel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HostelDatabaseContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
                .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            {
                entry.Entity.ModifiedOn = DateTime.Now;
                entry.Entity.ModifiedBy = _userService.UserId;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedOn = DateTime.Now;
                    entry.Entity.CreatedBy = _userService.UserId;
                }
            }
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
