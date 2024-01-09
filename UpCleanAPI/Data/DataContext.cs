using Microsoft.EntityFrameworkCore;
using System.Numerics;
using UpCleanAPI.Models;

namespace UpCleanAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Service> Services { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasOne(c => c.Address)
            .WithOne()
                .HasForeignKey<Client>(c => c.IdAddress)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Request>()
                .HasOne(r => r.Client)
                .WithMany(c => c.Requests)
                .HasForeignKey(r => r.IdClient)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
