using MarampaWebApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MarampaWebApi
{

    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) { }

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
    }
}