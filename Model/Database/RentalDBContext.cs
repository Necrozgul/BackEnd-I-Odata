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
                string conn =@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database\Database.mdf;Integrated Security=True";
                builder.UseLazyLoadingProxies().UseSqlServer(conn);
            }
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {

            mb.Entity<Device>(entity =>
            {
                entity.HasOne(device => device.Contract)
                    .WithMany(contract => contract.Devices)
                    //.HasForeignKey(device => device.ContractId)
                    .OnDelete(DeleteBehavior.Restrict);

                //entity.HasOne(device => device.Contract)
                //    .WithMany(contract => contract.Devices)
                //    .HasForeignKey(device => device.DeviceContractId)
                //    .OnDelete(DeleteBehavior.Restrict);
            });
            Contract c1 = new Contract() { ContractKey=1};
            Contract c2 = new Contract() { ContractKey = 2 };
            Device n1 = new Device() { DeviceKey = 1, Name = "Device Test1", Price=50, State="Available"};
            Device n2 = new Device() { DeviceKey = 2, Name = "Device Test2", Price = 100, State = "Rented"};
            mb.Entity<Device>().HasData(n1, n2);
            
        }
    }
}
