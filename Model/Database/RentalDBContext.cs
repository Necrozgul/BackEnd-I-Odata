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
        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<Contract_Device> Contract_Device_Relations { get; set; }
        public virtual DbSet<History> History { get; set; }

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
            //Connection between Device and Contracts with a connection table
            mb.Entity<Contract_Device>().HasKey(pt => new { pt.DeviceId, pt.ContractId });
            mb.Entity<Contract_Device>().HasOne(y => y.Device).WithMany(y => y.Contract_Device_Relations).HasForeignKey(y => y.DeviceId).OnDelete(DeleteBehavior.Restrict);
            mb.Entity<Contract_Device>().HasOne(x => x.Contract).WithMany(x => x.Contract_Device_Relations).HasForeignKey(x => x.ContractId).OnDelete(DeleteBehavior.Restrict);

            //Connection between InstallationStatus and Device
            mb.Entity<Device>(entity =>
            {
                entity.HasOne(dev => dev.Status)
                    .WithMany(x => x.Devices)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            Contract c1 = new Contract() { 
                Id=1, Name="Contract1", 
                Startdate=DateTime.Now, 
                Enddate= new DateTime(2022, 12, 31, 23, 59, 59),
                Email="contract1@c1.com",
                Phone="15234356345",
                Address="test street 1"
            };
            Contract c2 = new Contract()
            {
                Id = 2,
                Name = "Contract2",
                Startdate = DateTime.Now,
                Enddate = new DateTime(2022, 12, 31, 23, 59, 59),
                Email = "contract2@c2.com",
                Phone = "152343563222",
                Address = "test street 2"
            };
            Device n1 = new Device() { Id = 1, Name = "Device Test1", Price=50, State="Available"};
            Device n2 = new Device() { Id = 2, Name = "Device Test2", Price = 100, State = "Rented"};
            mb.Entity<Contract>().HasData(c1, c2);
            mb.Entity<Device>().HasData(n1, n2);
            
        }
    }
}
