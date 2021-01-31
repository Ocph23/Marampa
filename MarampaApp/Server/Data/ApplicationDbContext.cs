using IdentityServer4.EntityFramework.Options;
using MarampaApp.Models;
using MarampaApp.Server.Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MarampaApp.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions) { }

        public DbSet<TahunPelayanan> TahunPelayanan { get; set; }
        public DbSet<Gereja> Gereja { get; set; }
        public DbSet<Keluarga> Keluarga { get; set; }
        public DbSet<Jemaat> Jemaat { get; set; }
        public DbSet<Rayon> Rayon { get; set; }
        public DbSet<Baptis> Baptis { get; set; }
        public DbSet<Sidi> Sidi { get; set; }
        public DbSet<Nikah> Nikah { get; set; }
        public DbSet<Meninggal> Meninggal { get; set; }
        public DbSet<Pekerjaan> Pekerjaan { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Jemaat>().HasIndex(u => u.NIK).HasFilter("NIK IS NOT NULL").IsUnique();
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            BeforeUpdate();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            BeforeUpdate();
            return (await base.SaveChangesAsync(acceptAllChangesOnSuccess,
                          cancellationToken));
        }

        private void BeforeUpdate()
        {
            var entries = ChangeTracker.Entries();
            var utcNow = DateTime.UtcNow;
            foreach (var entry in entries)
            {
                if (entry.Entity is Entity trackable)
                {
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            trackable.Updated = utcNow;
                            entry.Property("Created").IsModified = false;
                            break;

                        case EntityState.Added:
                            trackable.Created = utcNow;
                            trackable.Updated = utcNow;
                            break;
                    }
                }
            }
        }
    }
}

