using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class RentalDBContext : DbContext
    {
        public DbSet<Device> Devices { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<History> History { get; set; }
        public RentalDBContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                string conn =@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True";
                builder.UseLazyLoadingProxies().UseSqlServer(conn);
            }
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {

            mb.Entity<Device>(entity =>
            {
                entity.HasOne(device => device.Contract)
                    .WithMany(contract => contract.Devices)
                    .HasForeignKey(device => device.ContractId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(device => device.Contract)
                    .WithMany(contract => contract.Devices)
                    .HasForeignKey(device => device.ContractId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
